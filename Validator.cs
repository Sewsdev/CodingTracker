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

    public static bool IsStartDateEarlierThanEndDate(DateTime startDate, DateTime endDate)
    {
        return DateTime.Compare(startDate, endDate) > 0;
    }
}