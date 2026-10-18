namespace Lab_6;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public sealed class SolvencyCheckAttribute : Attribute
{
    public string BalanceProperty { get; }
    public string OverdraftProperty { get; }
    public string Message { get; set; } = "Баланс з урахуванням овердрафту не може бути від'ємним.";

    public SolvencyCheckAttribute(string balanceProperty, string overdraftProperty)
    {
        BalanceProperty = balanceProperty;
        OverdraftProperty = overdraftProperty;
    }
}