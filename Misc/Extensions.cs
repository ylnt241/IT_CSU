namespace IT_CSU.Misc;

public static class StringExtensions
{
    public static bool ContainsUnavailableSymbols(this string str)
    {
        const string availableSymbols = Program.Digits + ",.-+*^=";
        var unavailableSymbols = new List<char>();
        foreach (var c in str.Where(c => availableSymbols.IndexOf(c) == -1 && !unavailableSymbols.Contains(c)))
        {
            unavailableSymbols.Add(c);
        }

        if (unavailableSymbols.Count > 0)
        {
            var strOfSymbols = new StringBuilder();
            unavailableSymbols.ForEach(c => strOfSymbols.Append(c));
            AnsiConsole.MarkupLine(
                $"[bold red] ERROR:[/][bold] You can`t use this symbols:[/] [red]{Markup.Escape($"{strOfSymbols.ToString()}")}[/]");
        }

        return unavailableSymbols.Count > 0;
    }
}

public static class NumberExtensions
{
    public static bool IsValidOperation(this string str)
    {
        Console.WriteLine("222");
        return 1 > 0;
    }
}