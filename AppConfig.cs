using System.Globalization;
using Microsoft.Extensions.Configuration;

namespace CodingTracker;

internal sealed class AppConfig
{
    public string DbConnectionString { get; }
    public DateTimeSettings DateTimeSettings { get; }

    public AppConfig(IConfiguration configuration)
    {
        DbConnectionString = configuration.GetConnectionString("Database") ?? throw new InvalidOperationException("Database connection string missing.");
        DateTimeSettings = new DateTimeSettings(configuration);
    }
}

internal sealed class DateTimeSettings
{
    public string Format { get; }
    public CultureInfo Culture { get; }
    public DateTimeStyles Styles { get; }

    public DateTimeSettings(IConfiguration configuration)
    {
        Format = configuration["DateTime:Format"] ?? "dd/MM/yyyy HH:mm";

        var cultureSetting = configuration["DateTime:Culture"] ?? "Invariant";
        Culture = cultureSetting == "Invariant"
            ? CultureInfo.InvariantCulture
            : CultureInfo.GetCultureInfo(cultureSetting);

        Styles = DateTimeStyles.None;
    }
}