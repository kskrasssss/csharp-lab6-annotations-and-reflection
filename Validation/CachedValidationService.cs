using System.Reflection;

namespace Lab_6;

public class CachedValidationService : IValidationService
{
    private const BindingFlags Flags =
        BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

    private readonly Dictionary<Type, ClassValidationMetadata> _cache = new();

    public int CachedTypesCount => _cache.Count;

    public ValidationResult Validate(object entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        Type type = entity.GetType();
        if (!_cache.TryGetValue(type, out ClassValidationMetadata? metadata))
        {
            metadata = BuildMetadata(type); // дорога рефлексія лише при першому зверненні
            _cache[type] = metadata;
        }

        var result = new ValidationResult();

        if (metadata.ClassRule is not null)
        {
            object? balance = metadata.BalanceProperty?.GetValue(entity);
            object? overdraft = metadata.OverdraftProperty?.GetValue(entity);

            var error = ValidationRules.CheckSolvency(balance, overdraft, metadata.ClassRule);
            if (error is not null)
                result.AddError(
                    $"{metadata.ClassRule.BalanceProperty} + {metadata.ClassRule.OverdraftProperty}", error);
        }

        foreach (PropertyRule rule in metadata.PropertyRules)
        {
            object? value = rule.Property.GetValue(entity);
            ValidationRules.CheckMember(result, rule.Property.Name, value, rule.Iban, rule.Range);
        }

        return result;
    }

    private static ClassValidationMetadata BuildMetadata(Type type)
    {
        var classRule = type.GetCustomAttribute<SolvencyCheckAttribute>();

        var rules = new List<PropertyRule>();
        foreach (PropertyInfo property in type.GetProperties(Flags))
        {
            var iban = property.GetCustomAttribute<IbanFormatAttribute>();
            var range = property.GetCustomAttribute<NumericRangeAttribute>();
            if (iban is null && range is null) continue;
            rules.Add(new PropertyRule(property, iban, range));
        }

        return new ClassValidationMetadata
        {
            ClassRule = classRule,
            BalanceProperty = classRule is null ? null : type.GetProperty(classRule.BalanceProperty, Flags),
            OverdraftProperty = classRule is null ? null : type.GetProperty(classRule.OverdraftProperty, Flags),
            PropertyRules = rules
        };
    }
}
