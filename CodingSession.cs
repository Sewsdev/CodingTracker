namespace CodingTracker;

public class CodingSession
{
    public int Id { get; init; }
    public DateTime StartTime { get; init; }
    public DateTime EndTime { get; init; }
    public TimeSpan Duration => EndTime.Subtract(StartTime);
}