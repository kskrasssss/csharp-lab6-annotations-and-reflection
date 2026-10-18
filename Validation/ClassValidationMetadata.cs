using System.Reflection;

namespace Lab_6;

public sealed record PropertyRule(
    PropertyInfo Property,
    IbanFormatAttribute? Iban,
    NumericRangeAttribute? Range);

public sealed class ClassValidationMetadata
{
    public SolvencyCheckAttribute? ClassRule { get; init; }
    public PropertyInfo? BalanceProperty { get; init; }
    public PropertyInfo? OverdraftProperty { get; init; }
    public IReadOnlyList<PropertyRule> PropertyRules { get; init; } = Array.Empty<PropertyRule>();
}