using IT_CSU.Misc;

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
        string[] minusesInNumber = number.TakeNumber(UserInput.Separator).Split('-');
        byte countMinus = (byte)(minusesInNumber.Length - 1);
        return (countMinus != 0 && countMinus % 2 != 0);
    }

    public static bool IsValidBase(this byte numberBase)
    {
        if (numberBase >= 2 && numberBase <= 50) return true;
        else
        {
            Console.WriteLine("Дружочек! Можно использовать только системы счисления с основаниями от 2 до 50!");
            return false;
        }
    }
    public static decimal ConvertToDecimal(this string numberAsString, byte originalBase)
    {
        if (originalBase == 10)
            return decimal.Parse(numberAsString);
        string[] parts = numberAsString.Split(',', '.');
        string numberIntPart = parts[0];
        string numberFracPart = parts.Length > 1 ? parts[1] : "";

        decimal result = 0;
        for (int i = 0; i < numberIntPart.Length; i++)
        {
            int digitValue = Program.Digits.IndexOf(numberIntPart[i]);
            result = result * originalBase + digitValue;
        }

        if (numberFracPart.Length > 0)
        {
            int fractionalValue = 0;
            for (int i = numberFracPart.Length - 1; i >= 0; i--)
            {
                int digitValue = Program.Digits.IndexOf(numberFracPart[i]);
                fractionalValue = (fractionalValue + digitValue) / originalBase;
            }

            result += fractionalValue;
        }

        return result;
    }
    public static string ConvertFromDecimal(this decimal number, int targetBase)
    {
        if (targetBase == 10)
            return number.ToString();
        if (number == 0) return "0";

        // Целая часть
        decimal integerPart = Math.Floor(number);
        decimal fractionalPart = number - integerPart;

        string integerResult = "";

        // Конвертируем целую часть
        while (integerPart > 0)
        {
            int remainder = (int)(integerPart % targetBase);
            integerResult = Program.Digits[remainder] + integerResult;
            integerPart /= targetBase;
        }

        if (integerResult == "") integerResult = "0";

        // Конвертируем дробную часть
        string fractionalResult = "";
        int precision = 10;

        while (fractionalPart > 0 && fractionalResult.Length < precision)
        {
            fractionalPart *= targetBase;
            int digit = (int)Math.Floor(fractionalPart);
            fractionalResult += Program.Digits[digit];
            fractionalPart -= digit;
        }

        return fractionalResult.Length > 0 ? integerResult + "." + fractionalResult : integerResult;
    }
}