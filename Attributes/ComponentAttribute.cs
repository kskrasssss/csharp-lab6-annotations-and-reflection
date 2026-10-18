namespace Lab_6;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public sealed class ComponentAttribute : Attribute
{
    public string Name { get; set; } = string.Empty;
    public string Version { get; set; } = "1.0";
}
