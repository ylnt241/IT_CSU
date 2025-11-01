using IT_CSU.Misc;
using System.Globalization;

namespace IT_CSU.Numbers;

public static class NumbersExtensions
{
    public static bool ContainsOneOrLessDecimalPoint(this string str)
    {
        if (str.Split(',', '.').Length > 2)
        {
            Console.WriteLine($"Дружочек! Число с плавающей точкой введено неправильно! Позор тебе и стыд!");
            return false;
        }
        return true;
    }
    public static bool IsNegativeNumberAsString(this string number)
    {
        string[] minusesInNumber = number.TakeNumber().Split('-');
        byte countMinus = (byte)(minusesInNumber.Length - 1);
        if (countMinus == 0)
            Console.WriteLine("В числе нет знаков минуса, поэтому оно положительно.");
        else if (countMinus % 2 == 0)
            Console.WriteLine("В числе содержится чётное количество знаков минуса, поэтому оно положительно.");
        else
            Console.WriteLine("Число отрицательно.");
        return (countMinus != 0 && countMinus % 2 != 0);
    }

    public static bool IsValidBase(this byte numberBase)
    {
        if (numberBase is >= 2 and <= 50) return true;
        else
        {
            Console.WriteLine("Дружочек! Можно использовать только системы счисления с основаниями от 2 до 50!");
            return false;
        }
    }
    public static decimal ConvertToDecimal(this string numberAsString, byte originalBase)
    {
        Console.WriteLine("Переведём число в десятичную систему счисления.");
        if (originalBase == 10)
        {
            Console.WriteLine("Исходное основание равно 10, поэтому не требуется дополнительных действий.");
            return decimal.Parse(numberAsString);
        }
        string[] parts = numberAsString.Split(',', '.');
        string numberIntPart = parts[0];
        string? numberFracPart = parts.Length > 1 ? parts[1] : "";
        if (numberFracPart != "")
            Console.WriteLine($"Делим число на две части: целую {numberIntPart} и десятичную {numberFracPart}");
        decimal result = 0;
        foreach (var t in numberIntPart)
        {
            int digitValue = Program.Digits.IndexOf(t);
            Console.WriteLine($"{t} = {digitValue}");
            Console.WriteLine(
                $"Промежуточный результат: текущий результат ({result}) умножаем на изначальную систему счисления ({originalBase}) и прибавляем цифру {digitValue})");
            result = result * originalBase + digitValue;
            Console.WriteLine($"Целая часть числа = {result}");
        }

        if (numberFracPart.Length > 0)
        {
            Console.WriteLine("Начинаем переводить десятичную часть числа");
            decimal fractionalValue = 0;
            // for (int i = numberFracPart.Length - 1; i >= 0; i--)
            // {
            //     int digitValue = Program.Digits.IndexOf(numberFracPart[i]);
            //     Console.WriteLine($"{numberFracPart[i]} = {digitValue}");
            //     Console.WriteLine($"({fractionalValue} + {digitValue})/{originalBase}");
            //     fractionalValue = (fractionalValue + digitValue) / originalBase;
            // }
            for (int i = 0; i < numberFracPart.Length; i++)
            {
                // todo: добавить пояснения для 5-клашек
                int digitValue = Program.Digits.IndexOf(numberFracPart[i]);
                fractionalValue = fractionalValue + (decimal)(digitValue / Math.Pow(originalBase, i + 1));
            }
            Console.WriteLine($"Результат перевода десятичной части = {fractionalValue}");
            Console.WriteLine(
                $"Сложим целую часть и десятичную, чтобы получить конечное число: {result} + {fractionalValue} = {result + fractionalValue}");
            result += fractionalValue;
        }
        Console.WriteLine($"Таким образом, результатом перевода {numberAsString} из {originalBase} в систему счисления с основанием 10 является {result}");
        return result;
    }
    public static string ConvertFromDecimal(this decimal number, int targetBase)
    {
        if (targetBase == 10)
            return number.ToString(CultureInfo.InvariantCulture);
        if (number == 0) return "0";

        // Целая часть
        decimal integerPart = Math.Floor(number);
        decimal fractionalPart = number - integerPart;
        if (fractionalPart > 0)
            Console.WriteLine($"Разделим число на две части: целую {integerPart} и десятичную {fractionalPart}");
        string integerResult = "";

        Console.WriteLine($"Начнём переводить целую часть из десятичной в {targetBase}");
        // Конвертируем целую часть
        while (integerPart > 0)
        {
            int remainder = (int)(integerPart % targetBase);
            integerResult = Program.Digits[remainder] + integerResult;
            Console.WriteLine(
                $"Найдём остаток от деления {integerPart} на {targetBase} = {Program.Digits[remainder]} это и есть цифра нашего конечно числа");
            Console.WriteLine(
                $"Теперь найдём целое этого деления: {integerPart} / {targetBase} = {integerPart / targetBase}, это то, на что мы будем делить дальше, чтобы найти следующую цифру конечного числа.");
            integerPart /= targetBase;
        }
        if (integerResult == "") integerResult = "0";
        Console.WriteLine($"Целая часть искомого числа равна {integerResult}");
        
        string fractionalResult = "";
        if (fractionalPart > 0)
        {
            // Конвертируем дробную часть
            int precision = 10;
            Console.WriteLine($"Определим насколько точным будет наше число, т.е. сколько цифр после запятой мы будем использовать. В данном случае мы будем использовать {precision} цифр после запятой");
            while (fractionalPart > 0 && fractionalResult.Length < precision)
            {
                Console.WriteLine($"Умножаем {fractionalPart} на {targetBase} и получаем {fractionalPart * targetBase}");
                fractionalPart *= targetBase;
                int digit = (int)Math.Floor(fractionalPart);
                Console.WriteLine($"Возьмём целую часть от получившегося числа - {digit}");
                fractionalResult += Program.Digits[digit];
                Console.WriteLine($"Запишем промежуточный результат - {fractionalResult}");
                Console.WriteLine($"Вычтем из десятичной части уже записанную цифру - {fractionalPart} - {digit}");
                fractionalPart -= digit;
                Console.Write($" = {fractionalPart}");
            }

        }
        Console.WriteLine(fractionalResult.Length > 0
            ? $"Объединим уже переведённые целую и десятичную части {integerResult}.{fractionalResult} - это и будет переведённое число"
            : $"Итоговый результат - {integerResult}");
        return fractionalResult.Length > 0 ? integerResult + "." + fractionalResult : integerResult;
    }
}