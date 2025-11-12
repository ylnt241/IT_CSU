namespace IT_CSU.UserInput;

public class Greeting
{
    public static bool GetGreeting()
    {
        Console.Clear();
        AnsiConsole.Markup(
            "This is calculator for a different number systems. With it you can add, multiply and convert various numbers!\n");
        var confirmation = AnsiConsole.Prompt(
            new TextPrompt<bool>("Do you want to see advanced explanations while processing numbers?")
                .AddChoice(true)
                .AddChoice(false)
                .DefaultValue(true)
                .WithConverter(choice => choice ? "y" : "n"));
       AnsiConsole.MarkupLine(confirmation ? "You[bold green] will see [/]advanced explanations :check_mark_button:" : "You[bold red] will not [/]see advanced explanations :cross_mark:"); 
       return confirmation;
    }
}