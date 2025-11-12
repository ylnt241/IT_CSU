namespace IT_CSU.UserInput;

public class ProcessInput
{
    public static void Process(string input)
    {
        var inputParts = new List<string>(input.Split());
        while (inputParts.Count > 1)
        {
            var operation = inputParts.IndexOf(
                inputParts.First(s => Program.Operations.Contains(s)));
            var firstNumber = inputParts[operation - 1];
            var secondNumber = inputParts[operation + 1];
            
            inputParts.RemoveRange(operation-1, 3);
               
        }
    }
}