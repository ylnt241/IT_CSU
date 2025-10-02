using System.Text;

namespace IT_CSU.Misc;

public static class StringExtensions
{
    public static bool IsNullOrEmpty(this string input)
    {
        if (String.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine($"Дружочек, ты забыл ударить свое лицо об клавиатуру! Бегом исправлять!");
            return true;
        }
        else return false;

    }

    public static string TakeNumber(this string str, char separator)
    {
        return str.Split(separator)[0];
    }
    public static string TakeOldBase(this string str, char separator)
    {
        return str.Split(separator)[1];
    }
    public static string TakeNewBase(this string str, char separator)
    {
        return str.Split(separator)[2];
    }

    public static (string, string, string) SplitInput(this string str, char separator)
    {
        string number = str.TakeNumber(separator);
        string oldBase = str.TakeOldBase(separator);
        string newBase = str.TakeNewBase(separator);
        return (number, oldBase, newBase);
    }

    public static bool IsStringDigit(this string str)
    {
        foreach (char c in str)
        {
            if (!Char.IsDigit(c))
                return false;
        }

        return true; 
    }
    public static string WithOutDecimalPoint(this string str)
    {
        return str.Replace(".", "").Replace(",", "");
    }
    public static string WithOutMinus(this string str)
    {
        return str.Replace("-", "");
    }

    public static bool ContainsUnavailableSymbols(this string str)
    {
        StringBuilder sbUnavailableSymbols = new StringBuilder();
        bool valid = false;
        string availableSymbols = Program.Digits + ",.-";
        foreach (char c in str)
        {
            if (availableSymbols.IndexOf(c) == -1)
            {
                valid = true;
                sbUnavailableSymbols.Append(c);
                continue;
            }
        }
        if (sbUnavailableSymbols.Length > 0) Console.WriteLine($"Вы не можете использовать эти символы: {sbUnavailableSymbols}");
        return valid;
    }
}
