namespace CodingTracker;

internal static class Validator
{
    public static bool IsCorrectDateTimeFormat(string dateTimeString,DateTimeSettings dateTimeSettings)
    {
        return DateTime.TryParseExact(dateTimeString,
            dateTimeSettings.Format,
            dateTimeSettings.Culture,
            dateTimeSettings.Styles,
            out _);
    }

    public static bool IsDateLaterThan(DateTime date, DateTime comparisonDate)
    {
        return DateTime.Compare(date, comparisonDate) > 0;
    }

    public static bool IsNotFutureDate(DateTime dateTime)
    {
        return DateTime.Compare(dateTime, DateTime.Now) < 0;
    }
}