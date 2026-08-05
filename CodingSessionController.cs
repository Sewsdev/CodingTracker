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
        
        DateTime startDate = InputReader.GetDate("Start date:", _appConfig.DateTimeSettings);
        DateTime endDate = InputReader.GetDate("End date:", _appConfig.DateTimeSettings);

        while (!Validator.IsStartDateEarlierThanEndDate(startDate, endDate))
        {
            AnsiConsole.MarkupLine("[red]End date must be later than the start date.[/]");
            endDate = InputReader.GetDate("End date:", _appConfig.DateTimeSettings);
        }
        
        _codingSessionRepository.Add(new CodingSession
        {
            StartDate = startDate,
            EndDate = endDate
        });
    }
}