namespace Lab_6;

public static class Task1Demo
{
    public static void Run()
    {
        Type type = typeof(BankAccount);
        Console.WriteLine($"Клас: {type.Name}");

        foreach (var attr in type.GetCustomAttributes(false))
            Console.WriteLine($"  [клас] {attr.GetType().Name}");

        Console.WriteLine("\nВластивості:");
        foreach (var prop in type.GetProperties())
        {
            var attrs = prop.GetCustomAttributes(false);
            string list = attrs.Length == 0
                ? "(без атрибутів)"
                : string.Join(", ", attrs.Select(a => a.GetType().Name));
            Console.WriteLine($"  {prop.PropertyType.Name,-10} {prop.Name,-16} {list}");
        }
    }
}