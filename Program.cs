using IT_CSU.UserInput;

namespace IT_CSU;

class Program
{
    public const string Operations = "+*="; 
    public const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    public static bool ShowExplanations;
    static void Main(string[] args)
    {
        ShowExplanations = Greeting.GetGreeting();
        Shell.Hell();
    }
}
