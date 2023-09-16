namespace RestClientExamples.Cli;

public static class ConsoleHelper
{
    public static string GetUserInput(string prompt, bool firstTimePrompting = true, params string[] allowedValues)
    {
        if (!firstTimePrompting)
        {
            Console.WriteLine("Invalid input, please choose a valid option");
        }
        else
        {
            Console.WriteLine(prompt);
        }

        var input = Console.ReadLine();

        if (input == null || !allowedValues.Contains(input))
        {
            GetUserInput(prompt, firstTimePrompting: false, allowedValues);
        }

        return input;
    }
}
