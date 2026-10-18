namespace Lab_6;

public static class Task2Demo
{
    public static void Run()
    {
        IValidationService validator = new ValidatorService();

        Print("Валідний об'єкт", SampleAccounts.Valid(), validator);
        Print("Невалідний об'єкт", SampleAccounts.Invalid(), validator);
    }

    private static void Print(string title, BankAccount account, IValidationService validator)
    {
        Console.WriteLine($"\n--- {title} ---");
        Console.WriteLine(account);

        ValidationResult result = validator.Validate(account);
        Console.WriteLine($"IsValid: {result.IsValid}");
        foreach (var error in result.Errors)
            Console.WriteLine($"  ✗ {error.MemberName}: {error.Message}");
    }
}
