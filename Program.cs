using IT_CSU.Numbers;

namespace IT_CSU;

internal class Program
{
    public const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        do
        {

                var result = "";
                byte finalBase = 0;
                var operation = UserInput.GetInputOfOperation();

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
                    case Operation.Convertion:
                        byte oldBase;
                        (result, oldBase, finalBase) = NumberConvertion();
                        break;
                }

                Console.WriteLine($"Результат: {result},[{finalBase}]");
                Console.Write("Press <1> to convert another number or any other key to exit...");
                var exit = Console.ReadKey();
                Console.WriteLine("");
                if (exit.KeyChar != '1') break;
        } while (true);

    }

    private static (string, byte) NumbersAddition()
    {
        var (firstNumber, firstNumberBase, secondNumber, secondNumberBase, finalBase) =
            UserInput.InputForAddAndMultiply();
        var number1 = new Number();
        var number2 = new Number();
        number1.SetValues(firstNumber, firstNumberBase);
        number2.SetValues(secondNumber, secondNumberBase);
        var resultInDecimalSystem = number1.GetDecimalValue() + number2.GetDecimalValue();
        var resultInDecimalSystemAsString = resultInDecimalSystem.ToString();
        var result = new NumberForConvertion();
        result.SetValues(resultInDecimalSystemAsString, 10, finalBase);
        return (result.GetValue(), finalBase);
    }

    private static (string, byte) NumbersMultiply()
    {
        var (firstNumber, firstNumberBase, secondNumber, secondNumberBase, finalBase) =
            UserInput.InputForAddAndMultiply();
        var number1 = new Number();
        var number2 = new Number();
        number1.SetValues(firstNumber, firstNumberBase);
        number2.SetValues(secondNumber, secondNumberBase);
        var resultInDecimalSystem = number1.GetDecimalValue() * number2.GetDecimalValue();
        var resultInDecimalSystemAsString = resultInDecimalSystem.ToString();
        var result = new NumberForConvertion();
        result.SetValues(resultInDecimalSystemAsString, 10, finalBase);
        return (result.GetValue(), finalBase);
    }

    private static (string, byte, byte) NumberConvertion()
    {
        var (number, oldBase, newBase) = UserInput.InputForConvert();
        var numberForConvertion = new NumberForConvertion();
        numberForConvertion.SetValues(number, oldBase, newBase);
        return (numberForConvertion.GetValue(), oldBase, newBase);
    }
}
