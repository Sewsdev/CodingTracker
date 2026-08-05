using Dapper;
using Microsoft.Data.Sqlite;

namespace CodingTracker;

internal class DatabaseInitializer
{
    private readonly string _connectionString;

    public DatabaseInitializer(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Initialize()
    {
        using var connection = new SqliteConnection(_connectionString);

        var sql = @"CREATE TABLE IF NOT EXISTS CodingSessions (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    StartDate TEXT NOT NULL,
                    EndDate TEXT NOT NULL)";

        connection.Execute(sql);
    }
}