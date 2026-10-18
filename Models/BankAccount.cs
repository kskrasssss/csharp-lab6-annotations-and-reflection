namespace Lab_6;

[SolvencyCheck(nameof(BankAccount.Balance), nameof(BankAccount.OverdraftLimit))]
public class BankAccount
{
    [IbanFormat(@"^[A-Z]{2}\d{2}[A-Z0-9]{11,30}$")]
    public string Iban { get; set; } = string.Empty;

    public decimal Balance { get; set; }

    [NumericRange(0, 50000, Message = "Ліміт овердрафту має бути в межах від 0 до 50000.")]
    public decimal OverdraftLimit { get; set; }

    public bool IsBlocked { get; set; }

    public DateTime OpenedOn { get; set; }

    public override string ToString() =>
        $"BankAccount {{ Iban = {Iban}, Balance = {Balance}, OverdraftLimit = {OverdraftLimit}, " +
        $"IsBlocked = {IsBlocked}, OpenedOn = {OpenedOn:yyyy-MM-dd} }}";
}