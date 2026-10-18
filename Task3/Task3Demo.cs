using System.Diagnostics;

namespace Lab_6;

public static class Task3Demo
{
    public static void Run()
    {
        Console.Write("Кількість ітерацій (Enter = 100000): ");
        if (!int.TryParse(Console.ReadLine(), out int iterations) || iterations <= 0)
            iterations = 100_000;

        BankAccount[] accounts = GenerateAccounts(iterations);

        // Прогрів JIT окремими екземплярами, щоб не псувати кеш і заміри.
        for (int i = 0; i < Math.Min(1000, iterations); i++)
        {
            new ValidatorService().Validate(accounts[i]);
            new CachedValidationService().Validate(accounts[i]);
        }

        var plain = new ValidatorService();
        var cached = new CachedValidationService();

        var (plainMs, plainValid) = Measure(plain, accounts);
        var (cachedMs, cachedValid) = Measure(cached, accounts);

        Console.WriteLine($"\nІтерацій: {iterations:N0}");
        Console.WriteLine($"{"Сервіс",-26}{"Час, мс",12}{"мкс/виклик",14}{"Валідних",12}");
        Console.WriteLine(new string('-', 64));
        PrintRow("ValidatorService", plainMs, iterations, plainValid);
        PrintRow("CachedValidationService", cachedMs, iterations, cachedValid);
        Console.WriteLine(new string('-', 64));
        Console.WriteLine($"Прискорення: x{plainMs / cachedMs:F2}");
        Console.WriteLine($"Типів у кеші: {cached.CachedTypesCount}");
    }

    private static (double Ms, int Valid) Measure(IValidationService service, BankAccount[] items)
    {
        int valid = 0;
        var sw = Stopwatch.StartNew();
        foreach (BankAccount item in items)
        {
            if (service.Validate(item).IsValid) valid++;
        }
        sw.Stop();
        return (sw.Elapsed.TotalMilliseconds, valid);
    }

    private static void PrintRow(string name, double ms, int iterations, int valid) =>
        Console.WriteLine($"{name,-26}{ms,12:F1}{ms * 1000 / iterations,14:F3}{valid,12}");

    // Однакове зерно: обидва сервіси отримують ті самі дані.
    private static BankAccount[] GenerateAccounts(int count)
    {
        var rnd = new Random(42);
        var items = new BankAccount[count];
        for (int i = 0; i < count; i++)
        {
            items[i] = new BankAccount
            {
                Iban = rnd.Next(4) == 0
                    ? $"BAD{rnd.Next(1000)}"
                    : $"UA{rnd.Next(10, 100)}{rnd.NextInt64(1_000_000_000_000_000L, 10_000_000_000_000_000L)}",
                Balance = rnd.Next(-5000, 20000),
                OverdraftLimit = rnd.Next(-100, 10000),
                IsBlocked = rnd.Next(2) == 0,
                OpenedOn = DateTime.Today.AddDays(-rnd.Next(3650))
            };
        }
        return items;
    }
}