using IT_CSU.Misc;
using System.Linq;
namespace IT_CSU.Numbers;

public class ValidateNumbers
{
    public static bool IsValidNumber(string number, byte oldBase)
    {
// todo: сделать проверку на отсутствие знаков разделителя в числе
        do
        {
            if (!number.ContainsOneOrLessDecimalPoint()) return false;
            string numberWithOutSeparator = (number.WithOutDecimalPoint()).WithOutMinus();
            for (int i = 0; i < numberWithOutSeparator.Length; i++)
            {
                int digitValue;
                if (oldBase < 10)
                {
                    string digits = Program.Digits.Substring(0, 10);
                    digitValue = digits.IndexOf(numberWithOutSeparator[i]);
                }
                else digitValue = (Program.Digits).IndexOf(numberWithOutSeparator[i]);

                if (digitValue >= oldBase)
                {
                    Console.WriteLine($"{numberWithOutSeparator[i]} не может быть использована в системе с осованием {oldBase}!!");
                    return false;
                }
                else
                    return true;
            }
        } while (true);
    }
}