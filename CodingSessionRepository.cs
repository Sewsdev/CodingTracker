using Microsoft.Data.Sqlite;

namespace CodingTracker;

using Dapper;

internal class CodingSessionRepository
{
    private readonly string _connectionString;

    public CodingSessionRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Add(CodingSession codingSession)
    {
        using var connection = new SqliteConnection(_connectionString);
        var sql = "INSERT INTO CodingSessions (StartTime, EndTime) VALUES (@startTime, @endTime)";
        connection.Execute(sql, new { startTime = codingSession.StartTime, endTime = codingSession.EndTime });
    }
}