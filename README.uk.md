🇬🇧 [English](README.md) | 🇺🇦 **Українська**

# 🔍 Lab6: Рушій валідації на атрибутах

Консольний застосунок на **C# / .NET**, що реалізує декларативну валідацію на користувацьких атрибутах і Reflection, з кешуванням метаданих, бенчмарком та динамічним сканером компонентів.

![C#](https://img.shields.io/badge/C%23-12-239120?logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-6.0%2B-512BD4?logo=dotnet&logoColor=white)
![Platform](https://img.shields.io/badge/platform-Windows%20%7C%20Linux%20%7C%20macOS-lightgrey)

## 📖 Про проєкт

Доменна модель це банківський рахунок (`BankAccount`). Правила валідації задаються користувацькими атрибутами (без `System.ComponentModel.DataAnnotations`), а перевіряються під час виконання рефлексивним рушієм.

| Модуль | Що робить |
|--------|-----------|
| **Атрибути** | `[SolvencyCheck]` (рівень класу: баланс разом з овердрафтом не може бути від'ємним), `[IbanFormat]` (перевірка за регулярним виразом) і `[NumericRange]` (перевірка діапазону). Атрибути лише зберігають метадані |
| **Валідатор** | `ValidatorService` досліджує об'єкт через Reflection і повертає `ValidationResult` з прапором `IsValid` та списком помилок з іменами полів |
| **Валідатор із кешем** | `CachedValidationService` розбирає тип один раз і зберігає метадані в `Dictionary<Type, ClassValidationMetadata>`. Містить бенчмарк на `Stopwatch` порівняно з версією без кешу |
| **Сканер компонентів** | Знаходить у збірці всі класи з `[Component]`, створює їх через `Activator`, встановлює властивість через `SetValue`, викликає `Execute` через `Invoke` і виводить стан |

## 🛠 Технології

- **C#** та **.NET 6.0+**
- **Користувацькі атрибути** та `AttributeUsage`
- **Reflection:** `Type`, `PropertyInfo`, `MethodInfo`, `Assembly`, `Activator`
- **Регулярні вирази:** `System.Text.RegularExpressions`
- **Бенчмаркінг:** `System.Diagnostics.Stopwatch`
- **Git / GitHub** для керування версіями

## 👤 Автор

**_Катерина Краснікова_**
GitHub: [@kskrasssss](https://github.com/kskrasssss)

## ⬇️ Як завантажити

**Через Git:**

```bash
git clone https://github.com/kskrasssss/csharp-lab6-annotations-and-reflection
cd csharp-lab6-annotations-and-reflection
```

**Без Git:** на сторінці репозиторію натисни **Code → Download ZIP**, розпакуй архів і відкрий папку в терміналі.

## ▶️ Як запустити

1. Встанови [.NET SDK 6.0 або новіше](https://dotnet.microsoft.com/download).
2. Перевір версію:
```bash
   dotnet --version
```
3. Зі свого каталогу проєкту (де лежить файл `.csproj`) виконай:
```bash
   dotnet build
   dotnet run -c Release
```

> 💡 Для бенчмарку використовуй конфігурацію `Release`: замір{ }
> у ній реалістичніші, ніж у `Debug`.

## 🖥 Використання

Після запуску з'явиться меню. Введи номер і натисни Enter:

| Ввід | Модуль |
|------|--------|
| `1` | Атрибути та модель `BankAccount` |
| `2` | Рефлексивний валідатор |
| `3` | Кешування метаданих та бенчмарк |
| `4` | Сканер компонентів |
| `0` | Вихід |

Правила валідації для `BankAccount`:

| Ціль | Правило |
|------|---------|
| Клас | `Balance + OverdraftLimit >= 0` |
| `Iban` | Відповідає `^[A-Z]{2}\d{2}[A-Z0-9]{11,30}$` |
| `OverdraftLimit` | Від 0 до 50000 |

## 📁 Структура

```text
├── Program.cs              # точка входу та меню
├── Attributes/             # користувацькі атрибути
├── Models/                 # BankAccount
├── Validation/             # валідатори, правила, кеш метаданих
├── Components/             # 10 демонстраційних компонентів
├── Data/                   # тестові рахунки
├── Task1/ ... Task4/       # демо-запуск модулів із меню
```

## 📝 Ліцензія

Проєкт створено в навчальних цілях. Використовуй вільно.