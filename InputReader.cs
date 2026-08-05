using Spectre.Console;

namespace CodingTracker;

internal static class InputReader
{
    public static DateTime GetDate(string message, DateTimeSettings dateTimeSettings)
    {
        const string errorMessage = "[red]Provide a date in valid format: dd/MM/yyyy HH:mm.[/]";
        
        var dateTimeString = AnsiConsole.Prompt(
            new TextPrompt<string>($"[cyan]{message}[/]")
                .ValidationErrorMessage(errorMessage)
                .Validate(input =>
                    Validator.IsCorrectDateTimeFormat(input, dateTimeSettings), 
                    errorMessage
                ));

        return DateTime.ParseExact(dateTimeString, dateTimeSettings.Format, dateTimeSettings.Culture, dateTimeSettings.Styles);
    }
}