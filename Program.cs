using IT_CSU.Numbers;
using IT_CSU.UserInput;
using System.Globalization;

namespace IT_CSU;

internal class Program
{
    public const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

    public static void Main()
    {
        do
        {
            var result = "";
            byte finalBase = 0;
            byte? oldBase = 0;
            var operation = UserInput.UserInput.GetInputOfOperation();

            switch (operation)
            {
                case Operation.Add:
                {
                    (result, finalBase) = NumbersAddition();
                    break;
                }
                case Operation.Multiply:
                {
                    (result, finalBase) = NumbersMultiply();
                    break;
                }
                case Operation.Conversion:
                    (result, oldBase, finalBase) = NumberConversion();
                    break;
            }

            Console.WriteLine(oldBase > 0
                ? $"Результат перевода из {oldBase}: {result},[{finalBase}]"
                : $"Результат: {result},[{finalBase}]");
            Console.Write("Press <1> to convert another number or any other key to exit...");
            var exit = Console.ReadKey();
            Console.WriteLine("");
            if (exit.KeyChar != '1') break;
        } while (true);
    }


    private static (string, byte) NumbersAddition()
    {
        var (firstNumberValue, firstNumberBase, secondNumberValue, secondNumberBase, finalBase) =
            UserInput.UserInput.InputForAddAndMultiply();
        Number firstNumber = new Number(), secondNumber = new Number();
        firstNumber.SetValues(firstNumberValue, firstNumberBase);
        secondNumber.SetValues(secondNumberValue, secondNumberBase);
        var resultInDecimalSystem = firstNumber.GetDecimalValue() + secondNumber.GetDecimalValue();
        var resultInDecimalSystemAsString = resultInDecimalSystem.ToString(CultureInfo.InvariantCulture);
        var result = new NumberForConvertion();
        result.SetValues(resultInDecimalSystemAsString, 10, finalBase);
        return (result.GetValue(), finalBase);
    }

    private static (string, byte) NumbersMultiply()
    {
        var (firstNumber, firstNumberBase, secondNumber, secondNumberBase, finalBase) =
            UserInput.UserInput.InputForAddAndMultiply();
        var number1 = new Number();
        var number2 = new Number();
        number1.SetValues(firstNumber, firstNumberBase);
        number2.SetValues(secondNumber, secondNumberBase);
        var resultInDecimalSystem = number1.GetDecimalValue() * number2.GetDecimalValue();
        var resultInDecimalSystemAsString = resultInDecimalSystem.ToString(CultureInfo.InvariantCulture);
        var result = new NumberForConvertion();
        result.SetValues(resultInDecimalSystemAsString, 10, finalBase);
        return (result.GetValue(), finalBase);
    }

    private static (string, byte, byte) NumberConversion()
    {
        var (number, oldBase, newBase) = UserInput.UserInput.InputForConvert();
        var numberForConversion = new NumberForConvertion();
        numberForConversion.SetValues(number, oldBase, newBase);
        return (numberForConversion.GetValue(), oldBase, newBase);
    }
}