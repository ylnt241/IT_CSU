using System.Diagnostics;
using IT_CSU.Misc;

namespace IT_CSU.UserInput;

public class Shell
{
    public void Hell()
    {
        while(true)
        {
            AnsiConsole.Markup("[bold blue]>>>[/] ");
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input) && !input.ContainsUnavailableSymbols())
            {
                var expressions = new List<string>(input.Split('(', ')'));
                var tempResult = "";
                for (int i = 0; expressions.Count > 1; i++)
                {
                    ProcessInput.Process();
                    
                }
                while (expressions.Length > 1)
                {
                }
                foreach (var element in expressions)
                {
                    ProcessInput.Process(element);
                }
            }

        }
    }
}