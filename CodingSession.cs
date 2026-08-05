namespace CodingTracker;

public class CodingSession
{
    public int Id { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    
    public TimeSpan Duration => EndDate.Subtract(StartDate);
}