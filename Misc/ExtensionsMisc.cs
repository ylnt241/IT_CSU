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

    public static string TakeNumber(this string str)
    {
        return str.Split(UserInput.UserInput.Separator)[0];
    }
    public static string TakeOldBase(this string str)
    {
        return str.Split(UserInput.UserInput.Separator)[1];
    }
    public static string TakeNewBase(this string str)
    {
        return str.Split(UserInput.UserInput.Separator)[2];
    }

    public static (string number, string oldBase, string newBase) SplitInput(this string str)
    {
      
        string[] stringSplited = str.Split(UserInput.UserInput.Separator);
        string number = stringSplited[0], oldBase = stringSplited[1], newBase = stringSplited[2];
        return (number, oldBase, newBase);
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
            }
        }
        if (sbUnavailableSymbols.Length > 0) Console.WriteLine($"Вы не можете использовать эти символы: {sbUnavailableSymbols}");
        return valid;
    }
}
