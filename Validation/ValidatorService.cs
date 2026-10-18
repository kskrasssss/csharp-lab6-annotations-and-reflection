using System.Reflection;

namespace Lab_6;

public class ValidatorService : IValidationService
{
    private const BindingFlags Flags =
        BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

    public ValidationResult Validate(object entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        var result = new ValidationResult();
        Type type = entity.GetType();

        // 1. Валідація рівня класу
        var classRule = type.GetCustomAttribute<SolvencyCheckAttribute>();
        if (classRule is not null)
        {
            object? balance = type.GetProperty(classRule.BalanceProperty, Flags)?.GetValue(entity);
            object? overdraft = type.GetProperty(classRule.OverdraftProperty, Flags)?.GetValue(entity);

            var error = ValidationRules.CheckSolvency(balance, overdraft, classRule);
            if (error is not null)
                result.AddError($"{classRule.BalanceProperty} + {classRule.OverdraftProperty}", error);
        }

        // 2. Валідація властивостей (публічних і закритих)
        foreach (PropertyInfo property in type.GetProperties(Flags))
        {
            var iban = property.GetCustomAttribute<IbanFormatAttribute>();
            var range = property.GetCustomAttribute<NumericRangeAttribute>();
            if (iban is null && range is null) continue;

            object? value = property.GetValue(entity);
            ValidationRules.CheckMember(result, property.Name, value, iban, range);
        }

        return result;
    }
}