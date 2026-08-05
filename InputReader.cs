using Spectre.Console;

namespace CodingTracker;

internal static class InputReader
{
    private static DateTime GetDate(string message, DateTimeSettings dateTimeSettings)
    {
        string errorMessage = $"[red]Provide a date in valid format: {dateTimeSettings.Format}.[/]";
        
        var dateTimeString = AnsiConsole.Prompt(
            new TextPrompt<string>($"[cyan]{message}[/]")
                .ValidationErrorMessage(errorMessage)
                .Validate(input =>
                    Validator.IsCorrectDateTimeFormat(input, dateTimeSettings), 
                    errorMessage
                ));

        return DateTime.ParseExact(dateTimeString, dateTimeSettings.Format, dateTimeSettings.Culture, dateTimeSettings.Styles);
    }

    public static DateTime GetDateWithValidation(string promptMessage, DateTimeSettings dateTimeSettings, Func<DateTime, bool> isValid, string validationErrorMessage)
    {
        var date = GetDate(promptMessage, dateTimeSettings);

        while (!isValid(date))
        {
            AnsiConsole.MarkupLine($"[red]{validationErrorMessage}[/]");
            date = GetDate(promptMessage, dateTimeSettings);
        }

        return date;
    }
    
    public static DateTime GetDateWithValidation<T>(string promptMessage, DateTimeSettings dateTimeSettings, T context, Func<DateTime, T, bool> isValid, string validationErrorMessage)
    {
        var date = GetDate(promptMessage, dateTimeSettings);

        while (!isValid(date, context))
        {
            AnsiConsole.MarkupLine($"[red]{validationErrorMessage}[/]");
            date = GetDate(promptMessage, dateTimeSettings);
        }

        return date;
    }
    
    public static void AwaitAnyKeyPress()
    {
        AnsiConsole.MarkupLine("Press any key to go back to the Main Menu");
        Console.ReadKey();
    }
}