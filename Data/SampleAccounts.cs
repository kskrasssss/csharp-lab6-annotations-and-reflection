namespace Lab_6;

public static class SampleAccounts
{
    public static BankAccount Valid() => new()
    {
        Iban = "UA213223130000026007233566001",
        Balance = 1500m,
        OverdraftLimit = 2000m,
        IsBlocked = false,
        OpenedOn = new DateTime(2022, 5, 14)
    };

    // Порушує: формат IBAN, діапазон овердрафту, правило платоспроможності.
    public static BankAccount Invalid() => new()
    {
        Iban = "BAD-IBAN-123",
        Balance = -300m,
        OverdraftLimit = -200m,
        IsBlocked = true,
        OpenedOn = new DateTime(2024, 1, 10)
    };
}