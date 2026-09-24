using GameBacklog.Cli.Enums;
using Microsoft.Data.Sqlite;

namespace GameBacklog.Cli.Data;

internal class SqliteDatabase
{
    private readonly string _connectionString;

    public SqliteDatabase(string connectionString)
    {
        _connectionString = connectionString;
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

    public void ShowGamesWithMinimumRating(int minimumRating)
    {
        using SqliteConnection connection =
            new SqliteConnection(_connectionString);

        connection.Open();

        string sql = """
            SELECT Title, Rating
            FROM Games
            WHERE Rating >= $minimumRating;
            """;

        using SqliteCommand command =
            new SqliteCommand(sql, connection);

        command.Parameters.AddWithValue("$minimumRating", minimumRating);

        using SqliteDataReader reader =
            command.ExecuteReader();

        while (reader.Read())
        {
            string title = reader.GetString(0);
            int rating = reader.GetInt32(1);

            Console.WriteLine($"Title: {title} | Rating: {rating}");
        }
    }

    public void AddGame(string title,
                        Platform platform,
                        GameState state,
                        int rating,
                        double playTimeHours)
    {
        using SqliteConnection connection =
            new SqliteConnection(_connectionString);

        connection.Open();

        string sql = """
            INSERT INTO Games
            (
                Title,
                Platform,
                State,
                Rating,
                PlayTimeHours
            )
            VALUES
            (
                $title,
                $platform,
                $state,
                $rating,
                $playTimeHours
            );
            """;

        using SqliteCommand command =
            new SqliteCommand(sql, connection);

        command.Parameters.AddWithValue("$title", title);
        command.Parameters.AddWithValue("$platform", (int)platform);
        command.Parameters.AddWithValue("$state", (int)state);
        command.Parameters.AddWithValue("$rating", rating);
        command.Parameters.AddWithValue("$playTimeHours", playTimeHours);

        command.ExecuteNonQuery();
    }

    public void DeleteGameById(int id)
    {
        using SqliteConnection connection =
            new SqliteConnection(_connectionString);

        connection.Open();

        string sql = """
            DELETE FROM Games
            WHERE Id = $id;
            """;

        using SqliteCommand command =
            new SqliteCommand(sql, connection);

        command.Parameters.AddWithValue("$id", id);
        
        int affectedRows = command.ExecuteNonQuery();

        if (affectedRows > 0)
        {
            Console.WriteLine($"{affectedRows} rows deleted");
        }
    }

    public void UpdateRating(int id, int rating)
    {
        using SqliteConnection connection = 
            new SqliteConnection(_connectionString);

        connection.Open();

        string sql = """
            UPDATE Games
            SET Rating = $rating
            WHERE Id = $id;
            """;

        using SqliteCommand command = 
            new SqliteCommand(sql, connection);

        command.Parameters.AddWithValue("$rating", rating);
        command.Parameters.AddWithValue("$id", id);

        int affectedRows = command.ExecuteNonQuery();

        Console.WriteLine($"affected Rows: {affectedRows}");
    }
}