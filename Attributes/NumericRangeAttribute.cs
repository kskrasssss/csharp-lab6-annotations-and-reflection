namespace Lab_6;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public sealed class NumericRangeAttribute : Attribute
{
    public double Min { get; }
    public double Max { get; }
    public string Message { get; set; } = "Значення поза допустимим діапазоном.";

    public NumericRangeAttribute(double min, double max)
    {
        Min = min;
        Max = max;
    }
}