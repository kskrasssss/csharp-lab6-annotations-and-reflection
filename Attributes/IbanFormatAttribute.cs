namespace Lab_6;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public sealed class IbanFormatAttribute : Attribute
{
    public string Pattern { get; }
    public string Message { get; set; } = "Некоректний формат IBAN.";

    public IbanFormatAttribute(string pattern)
    {
        Pattern = pattern;
    }
}
