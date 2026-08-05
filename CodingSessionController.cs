using Spectre.Console;

namespace CodingTracker;

internal class CodingSessionController
{
    private readonly CodingSessionRepository _codingSessionRepository;
    private readonly AppConfig _appConfig;

    public CodingSessionController(AppConfig appConfig)
    {
        _appConfig = appConfig;
        _codingSessionRepository = new CodingSessionRepository(appConfig.DbConnectionString);
    }
    
    public void Add()
    {
        AnsiConsole.MarkupLine($"[bold]Make sure the date you provide uses military time and is in the correct format ({_appConfig.DateTimeSettings.Format})[/]\n");
        
        DateTime startDate = InputReader.GetDateWithValidation(
            "Start date:",
            _appConfig.DateTimeSettings,
            Validator.IsNotFutureDate,
            "Start date can't be in the future."
            );

        DateTime endDate = InputReader.GetDateWithValidation(
            "End date:",
            _appConfig.DateTimeSettings,
            startDate,
            Validator.IsDateLaterThan,
            "End date must be later than the start date."
        );
        
        _codingSessionRepository.Add(new CodingSession
        {
            StartDate = startDate,
            EndDate = endDate
        });
    }
    
    public void ViewAll()
    {
        Console.Clear();
        
        var table = new Table();
        table.Border(TableBorder.Rounded);
  
        table.AddColumn("[cyan]ID[/]");
        table.AddColumn("[cyan]Start date[/]");
        table.AddColumn("[cyan]Start time[/]");
        table.AddColumn("[cyan]End date[/]");
        table.AddColumn("[cyan]End time[/]");
        table.AddColumn("[cyan]Duration[/]");
        
        var sessions = _codingSessionRepository.GetAll();
        
        foreach (var session in sessions)
        {
            table.AddRow(
                $"{session.Id}",
                $"{session.StartDate:dd MMMM yyyy}",
                $"{session.StartDate:HH:mm}",
                $"{session.EndDate:dd MMMM yyyy}",
                $"{session.EndDate:HH:mm}",
                $"{session.Duration}"
                );
        }
        
        AnsiConsole.Write(table);
        InputReader.AwaitAnyKeyPress();
        Console.Clear();
    }
}