using Microsoft.Data.Sqlite;

namespace GameBacklog.Cli.Data;

internal class SqliteDatabase
{
    private readonly string _connectionString;

    public SqliteDatabase(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void TestConnection()
    {
        using SqliteConnection connection =
            new SqliteConnection(_connectionString);

        connection.Open();

        Console.WriteLine("Database connection successful.");
    }

    public void ShowGames()
    {
        using SqliteConnection connection =
            new SqliteConnection(_connectionString);

        connection.Open();

        string sql = """
            SELECT Id, Title, Platform, State, Rating, PlayTimeHours
            FROM Games;
            """;

        using SqliteCommand command =
            new SqliteCommand(sql, connection);

        using SqliteDataReader reader =
            command.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string title = reader.GetString(1);
            int platform = reader.GetInt32(2);
            int state = reader.GetInt32(3);
            int rating = reader.GetInt32(4);
            double playTimeHours = reader.GetDouble(5);

            Console.WriteLine(
            $"{id} | {title} | {platform} | {state} | {rating} | {playTimeHours}");
        }
    }
}