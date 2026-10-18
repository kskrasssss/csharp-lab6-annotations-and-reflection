using System.Reflection;

namespace Lab_6;

public static class Task4Demo
{
    public static void Run()
    {
        // 1. Сканування збірки: типи-класи з атрибутом [Component]
        Assembly assembly = typeof(ComponentAttribute).Assembly;
        List<Type> componentTypes = assembly.GetTypes()
            .Where(t => t.IsClass && t.GetCustomAttribute<ComponentAttribute>() is not null)
            .OrderBy(t => t.Name)
            .ToList();

        Console.WriteLine($"Знайдено компонентів: {componentTypes.Count}");

        foreach (Type type in componentTypes)
        {
            var meta = type.GetCustomAttribute<ComponentAttribute>()!;
            Console.WriteLine($"\n>>> {type.Name} (name='{meta.Name}', version={meta.Version})");

            // 2. Динамічне створення екземпляра
            object instance = Activator.CreateInstance(type)!;

            // 3. Динамічне встановлення значення властивості
            PropertyInfo? property = type
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(p => p.CanWrite);
            if (property is not null)
                property.SetValue(instance, DemoValue(property.PropertyType));

            // 4. Динамічний виклик методу дії
            MethodInfo? execute = type.GetMethod("Execute", BindingFlags.Public | BindingFlags.Instance);
            execute?.Invoke(instance, null);

            // 5. Підсумковий стан через ToString()
            Console.WriteLine($"  Стан: {instance}");
        }
    }

    private static object? DemoValue(Type type)
    {
        if (type == typeof(string)) return "demo";
        if (type == typeof(int)) return 42;
        if (type == typeof(decimal)) return 250.75m;
        if (type == typeof(double)) return 39.5;
        if (type == typeof(bool)) return true;
        if (type == typeof(DateTime)) return DateTime.Today;
        return type.IsValueType ? Activator.CreateInstance(type) : null;
    }
}
