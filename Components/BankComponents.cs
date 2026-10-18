namespace Lab_6;

[Component(Name = "payments", Version = "1.2")]
public class PaymentProcessor
{
    public decimal Amount { get; set; }
    public void Execute() => Console.WriteLine($"  Проведення платежу на суму {Amount}");
    public override string ToString() => $"PaymentProcessor {{ Amount = {Amount} }}";
}

[Component(Name = "transfers", Version = "2.0")]
public class TransferService
{
    public string TargetIban { get; set; } = string.Empty;
    public void Execute() => Console.WriteLine($"  Переказ на рахунок {TargetIban}");
    public override string ToString() => $"TransferService {{ TargetIban = {TargetIban} }}";
}

public class CardIssuer
{
    public string HolderName { get; set; } = string.Empty;
    public void Execute() => Console.WriteLine($"  Випуск картки для {HolderName}");
    public override string ToString() => $"CardIssuer {{ HolderName = {HolderName} }}";
}

public class LoanCalculator
{
    public double AnnualRate { get; set; }
    public void Execute() => Console.WriteLine($"  Розрахунок кредиту під {AnnualRate}% річних");
    public override string ToString() => $"LoanCalculator {{ AnnualRate = {AnnualRate} }}";
}

[Component(Name = "fraud-detection", Version = "3.1")]
public class FraudDetector
{
    public int RiskThreshold { get; set; }
    public void Execute() => Console.WriteLine($"  Аналіз шахрайства, поріг ризику {RiskThreshold}");
    public override string ToString() => $"FraudDetector {{ RiskThreshold = {RiskThreshold} }}";
}

public class StatementGenerator
{
    public int Month { get; set; }
    public void Execute() => Console.WriteLine($"  Формування виписки за місяць №{Month}");
    public override string ToString() => $"StatementGenerator {{ Month = {Month} }}";
}

[Component(Name = "currency", Version = "1.5")]
public class CurrencyConverter
{
    public double Rate { get; set; }
    public void Execute() => Console.WriteLine($"  Конвертація за курсом {Rate}");
    public override string ToString() => $"CurrencyConverter {{ Rate = {Rate} }}";
}

[Component(Name = "notifications", Version = "1.0")]
public class NotificationSender
{
    public string Channel { get; set; } = string.Empty;
    public void Execute() => Console.WriteLine($"  Надсилання сповіщення каналом '{Channel}'");
    public override string ToString() => $"NotificationSender {{ Channel = {Channel} }}";
}

[Component(Name = "audit", Version = "2.3")]
public class AuditLogger
{
    public bool Verbose { get; set; }
    public void Execute() => Console.WriteLine($"  Запис аудиту, докладний режим: {Verbose}");
    public override string ToString() => $"AuditLogger {{ Verbose = {Verbose} }}";
}

public class ExchangeRateCache
{
    public int TtlSeconds { get; set; }
    public void Execute() => Console.WriteLine($"  Оновлення кешу курсів, TTL {TtlSeconds} с");
    public override string ToString() => $"ExchangeRateCache {{ TtlSeconds = {TtlSeconds} }}";
}