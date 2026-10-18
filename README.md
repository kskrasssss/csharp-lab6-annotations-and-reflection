🇬🇧 **English** | 🇺🇦 [Українська](README.uk.md)

# 🔍 Lab6: Attribute-Based Validation Engine

A **C# / .NET** console application that builds a declarative validation engine on top of custom attributes and Reflection, with metadata caching, a benchmark and a dynamic component scanner.

![C#](https://img.shields.io/badge/C%23-12-239120?logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-6.0%2B-512BD4?logo=dotnet&logoColor=white)
![Platform](https://img.shields.io/badge/platform-Windows%20%7C%20Linux%20%7C%20macOS-lightgrey)

## 📖 About

The domain model is a bank account (`BankAccount`). Validation rules are declared with custom attributes (without `System.ComponentModel.DataAnnotations`) and are enforced at runtime by a Reflection-based engine.

| Module | What it does |
|--------|--------------|
| **Attributes** | `[SolvencyCheck]` (class level: balance plus overdraft must not be negative), `[IbanFormat]` (regex check) and `[NumericRange]` (range check). Attributes only carry metadata |
| **Validator** | `ValidatorService` inspects an object via Reflection and returns a `ValidationResult` with an `IsValid` flag and a list of errors with member names |
| **Cached validator** | `CachedValidationService` parses a type once and stores the metadata in a `Dictionary<Type, ClassValidationMetadata>`. Includes a `Stopwatch` benchmark against the uncached version |
| **Component scanner** | Finds all classes marked with `[Component]` in the assembly, creates them with `Activator`, sets a property with `SetValue`, calls `Execute` with `Invoke` and prints the state |

## 🛠 Tech stack

- **C#** and **.NET 6.0+**
- **Custom attributes** and `AttributeUsage`
- **Reflection:** `Type`, `PropertyInfo`, `MethodInfo`, `Assembly`, `Activator`
- **Regular expressions:** `System.Text.RegularExpressions`
- **Benchmarking:** `System.Diagnostics.Stopwatch`
- **Git / GitHub** for version control

## 👤 Author

**_Kate Krasnikova_**
GitHub: [@kskrasssss](https://github.com/kskrasssss)

## ⬇️ Download

**With Git:**

```bash
git clone https://github.com/kskrasssss/csharp-lab6-annotations-and-reflection
cd csharp-lab6-annotations-and-reflection
```

**Without Git:** on the repository page click **Code → Download ZIP**, extract the archive and open the folder in a terminal.

## ▶️ Run

1. Install the [.NET SDK 6.0 or newer](https://dotnet.microsoft.com/download).
2. Check the version:
```bash
   dotnet --version
```
3. From the project directory (the one containing the `.csproj` file) run:
```bash
   dotnet build
   dotnet run -c Release
```

> 💡 Use the `Release` configuration for the benchmark: it gives more realistic timings than `Debug`.

## 🖥 Usage

After launch a menu appears. Enter a number and press Enter. The console text is in Ukrainian:

| Input | Module |
|-------|--------|
| `1` | Attributes and the `BankAccount` model |
| `2` | Reflection-based validator |
| `3` | Metadata caching and benchmark |
| `4` | Component scanner |
| `0` | Exit |

Validation rules for `BankAccount`:

| Target | Rule |
|--------|------|
| Class | `Balance + OverdraftLimit >= 0` |
| `Iban` | Must match `^[A-Z]{2}\d{2}[A-Z0-9]{11,30}$` |
| `OverdraftLimit` | Must be between 0 and 50000 |

## 📁 Project structure

```text
├── Program.cs              # entry point and menu
├── Attributes/             # custom attributes
├── Models/                 # BankAccount
├── Validation/             # validators, rules, metadata cache
├── Components/             # 10 sample components
├── Data/                   # sample accounts
├── Task1/ ... Task4/       # demo runners for the menu
```

## 📝 License

Created for educational purposes. Feel free to use it.