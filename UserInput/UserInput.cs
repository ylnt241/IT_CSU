using IT_CSU.Misc;
using IT_CSU.Numbers;

namespace IT_CSU.UserInput;

public class UserInput
{
    public static readonly char Separator = ';';
    public static Operation GetInputOfOperation()
    {
        Console.Clear();
        do
        {
            try
            {
                Console.WriteLine(
                    "Привет! Что ты хочешь сделать? \n1 - сложить два числа \n2 - умножить два числа\n3 - перевести число в другую систему счисления");
                Console.Write("Выбор:");
                string userInput = Console.ReadLine() ?? throw new InvalidOperationException();
                if (userInput.IsNullOrEmpty()) continue;
                Operation selectedOperation = userInput switch
                {
                    "1" => Operation.Add,
                    "2" => Operation.Multiply,
                    "3" => Operation.Conversion,
                    _ => throw new InvalidOperationException()
                };
                return selectedOperation;
            }
            catch
            {
                Console.WriteLine("Дружочек! Ты ткнул не ту цыфарку!");
            }
        } while (true);
    }

    public static (string, byte, string, byte, byte) InputForAddAndMultiply()
    {
        Console.Write("Введите первое число: ");
        string firstNumber = GetInputOfNumber();
        Console.Write("Введите основание системы счисления первого числа: ");
        byte firstNumberBase = GetInputOfBase();
        Console.Write("Введите второе число: ");
        string secondNumber = GetInputOfNumber();
        Console.Write("Введите основание системы счисления второго числа: ");
        byte secondNumberBase = GetInputOfBase();
        Console.Write("Введите основание системы счисления итогового числа: ");
        byte finalNumberBase = GetInputOfBase();
        return(firstNumber, firstNumberBase, secondNumber, secondNumberBase, finalNumberBase);
    }

    public static (string, byte, byte) InputForConvert()
    {
        Console.Write("Введите исходное число: ");
        string number = GetInputOfNumber();
        Console.Write("Введите начальное основание: ");
        byte oldBase = GetInputOfBase();
        Console.Write("Введите итоговое основание: ");
        byte newBase = GetInputOfBase();
        return (number, oldBase, newBase);
    }
    private static byte ConvertBaseToByte(string baseAsString)
    {
        byte baseAsByte;
        byte.TryParse(baseAsString, out baseAsByte);
        if (baseAsByte.IsValidBase()) return baseAsByte;
        throw new ArgumentException();
    }

    private static string GetInputOfNumber()
    {
        do
        {
            try
            {
                string number = Console.ReadLine() ?? throw new InvalidOperationException();
                if (number.IsNullOrEmpty() || number.ContainsUnavailableSymbols() || !number.ContainsOneOrLessDecimalPoint()) throw new ArgumentException();
                return number;
            }
            catch
            {
                Console.Write("Недопустимый ввод!\nВведи число:");
            }
        } while (true);
    }

    private static byte GetInputOfBase()
    {
        do
        {
            try
            {
                string inputOfBase = Console.ReadLine() ?? throw new InvalidOperationException();
                if (inputOfBase.IsNullOrEmpty() || inputOfBase.ContainsUnavailableSymbols() || inputOfBase.Split(',', '.').Length > 1)
                    throw new FormatException();
                var baseAsByte = ConvertBaseToByte(inputOfBase);
                return baseAsByte;
            }
            catch
            {
                Console.Write("Недопустимый ввод!\nВведи основание:");
            }
        } while (true);
    }

}
