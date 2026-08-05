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
        DateTime startTime = InputReader.GetDate("Start date:", _appConfig.DateTimeSettings);
        DateTime endTime = InputReader.GetDate("End date:", _appConfig.DateTimeSettings);
        _codingSessionRepository.Add(new CodingSession
        {
            StartTime = startTime,
            EndTime = endTime
        });
    }
}