// сама логіка перевірок: атрибути її не містять, а обидва сервіси використовують спільні правила, тож у бенчмарку різниця 
// буде саме від рефлексії
using System.Text.RegularExpressions;

namespace Lab_6;

public static class ValidationRules
{
    public static string? CheckIban(object? value, IbanFormatAttribute rule)
    {
        if (value is not string text || !Regex.IsMatch(text, rule.Pattern))
            return rule.Message;
        return null;
    }

    public static string? CheckRange(object? value, NumericRangeAttribute rule)
    {
        if (value is null) return "Значення відсутнє.";
        double number = Convert.ToDouble(value);
        return number < rule.Min || number > rule.Max ? rule.Message : null;
    }

    public static string? CheckSolvency(object? balance, object? overdraft, SolvencyCheckAttribute rule)
    {
        decimal b = Convert.ToDecimal(balance);
        decimal o = Convert.ToDecimal(overdraft);
        return b + o < 0 ? rule.Message : null;
    }

    // Застосовує атрибути поля до його значення й додає помилки у результат.
    public static void CheckMember(
        ValidationResult result,
        string memberName,
        object? value,
        IbanFormatAttribute? iban,
        NumericRangeAttribute? range)
    {
        if (iban is not null)
        {
            var error = CheckIban(value, iban);
            if (error is not null) result.AddError(memberName, error);
        }
        if (range is not null)
        {
            var error = CheckRange(value, range);
            if (error is not null) result.AddError(memberName, error);
        }
    }
}