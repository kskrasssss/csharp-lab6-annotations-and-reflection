Console.OutputEncoding = System.Text.Encoding.UTF8;

while (true)
{
    Console.WriteLine("\n=== Лабораторна робота №6 (варіант 8) ===");
    Console.WriteLine("1 - Атрибути та доменна модель BankAccount");
    Console.WriteLine("2 - Рефлексивний валідатор");
    Console.WriteLine("3 - Кешування метаданих та бенчмарк");
    Console.WriteLine("4 - Сканер компонентів");
    Console.WriteLine("0 - Вихід");
    Console.Write("Ваш вибір: ");

    switch (Console.ReadLine())
    {
        // case
        case "0": return;
        default: Console.WriteLine("Невірний вибір"); break;
    }
}