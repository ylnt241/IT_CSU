using System.Globalization;
using System.IO.Pipelines;
using System.Net;
using System.Security.Cryptography;

class Program
{
    public const string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    public static string GetInput()
    {
        do
        {
            Console.Write("Enter number to convert: ");
            string numberToConvert = Console.ReadLine();
            Console.Write("Enter original base of number: ");
            string origBase = Console.ReadLine();
            Console.Write("Enter new base: ");
            string newBase = Console.ReadLine();
            string userInput = numberToConvert + ';' + origBase + ';' + newBase;
            if (origBase == newBase)
            {
                return numberToConvert;
            }
            var answer = InputProcessing(userInput);
            if (answer != null)
            {
                if (IsNegativeNumber(userInput))
                {
                    return ('-' + answer);
                }
                else
                {
                    return answer;
                }
            }
        } while (true);
    }
    public static bool IsNegativeNumber(string userInput)
    {
        string[] parts = userInput.Split(';');
        int countMinus = ((parts[0]).Split('-')).Length - 1;
        if (countMinus != 0 || countMinus % 2 != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static string InputProcessing(string userInput)
    {
        string[] parts = userInput.Split(';');
        string numberAsString = parts[0];
        int originalBase = 0;
        int toBase = 0;
        if (parts[0].Split('-').Length > 1)
        {
            numberAsString = numberAsString.Replace("-", "");
        }
        // Проверка на валидность ввода числа с плавающей точкой
        if (numberAsString.Split(',', '.').Length > 2)
        {
            Console.WriteLine("\nInvalid input of decimal number!\n");
            return null;
        }

        try
        {
            if (!int.TryParse(parts[1], out originalBase) || !int.TryParse(parts[2], out toBase))
            {
                Console.WriteLine("\nBases must be integers!\n");
                return null;
            }

            if (originalBase < 2 || originalBase > 50 || toBase < 2 || toBase > 50)
            {
                Console.WriteLine("\nBases must be between 2 and 50!\n");
                return null;
            }
        }
        catch
        {
            Console.WriteLine("\nSomething went wrong..\n");
            return null;
        }

        // Проверка на соответствие форматированию
        string numberWithoutSeparators = numberAsString.Replace(",", "").Replace(".", "");
        for (int i = 0; i < numberWithoutSeparators.Length; i++)
        {
            int digitValue = digits.IndexOf(numberWithoutSeparators[i]);
            if (digitValue >= originalBase || digitValue == -1)
            {
                Console.WriteLine($"\n{numberWithoutSeparators[i]} can't be used in {originalBase} system!\n");
                return null;
            }
        }

        string answer = ConvertFromDecimal(ConvertToDecimal(numberAsString, originalBase), toBase);
        return answer;
    }
    public static decimal ConvertToDecimal(string numberAsString, int originalBase)
    {
        string[] parts = numberAsString.Split(',', '.');
        string numberIntPart = parts[0];
        string numberFracPart = parts.Length > 1 ? parts[1] : "";

        decimal result = 0;
        for (int i = 0; i < numberIntPart.Length; i++)
        {
            int digitValue = digits.IndexOf(numberIntPart[i]);
            result = result * originalBase + digitValue;
        }

        if (numberFracPart.Length > 0)
        {
            decimal fractionalValue = 0;
            for (int i = numberFracPart.Length - 1; i >= 0; i--)
            {
                int digitValue = digits.IndexOf(numberFracPart[i]);
                fractionalValue = (fractionalValue + digitValue) / originalBase;
            }
            result += fractionalValue;
        }

        return result;
    }
    public static string ConvertFromDecimal(decimal number, int targetBase)
    {
        if (number == 0) return "0";

        // Целая часть
        long integerPart = (long)Math.Floor(number);
        decimal fractionalPart = number - integerPart;

        string integerResult = "";

        // Конвертируем целую часть
        while (integerPart > 0)
        {
            int remainder = (int)(integerPart % targetBase);
            integerResult = digits[remainder] + integerResult;
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
            fractionalResult += digits[digit];
            fractionalPart -= digit;
        }

        return fractionalResult.Length > 0 ? integerResult + "." + fractionalResult : integerResult;
    }
    public static void Main()
    {
        do
        {
            Console.WriteLine("This is the program for conversion numbers to different bases.\nWe use 'A-Z' for first 11-36 digits and 'a-z' for next to 50.\nFor example if you want to convert 35 from base 41 to base 2, you need to type below:\nZ\n41\n2\n");
            var answer = GetInput();
            Console.WriteLine($"Answer is {answer}");
            Console.Write("Press <1> to convert another number or any other key to exit...");
            try
            {
                var exit = Console.ReadKey();
                Console.WriteLine("");
                if (exit.KeyChar != '1')
                {
                    break;
                }
            }
            catch
            {
                Console.WriteLine("\nCan`t read key. Exiting...");
                break;
            }
        } while (true);
    }
}