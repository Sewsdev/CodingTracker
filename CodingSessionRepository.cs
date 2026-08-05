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

    public List<CodingSession> GetAll()
    {
        using var connection = new SqliteConnection(_connectionString);
        var sql = "SELECT * FROM CodingSessions";
        return [.. connection.Query<CodingSession>(sql)];
    }
    
    public void Add(CodingSession codingSession)
    {
        using var connection = new SqliteConnection(_connectionString);
        var sql = "INSERT INTO CodingSessions (StartDate, EndDate) VALUES (@startDate, @endDate)";
        connection.Execute(sql, new { startDate = codingSession.StartDate, endDate = codingSession.EndDate });
    }
}