using GameBacklog.Cli.Data;

SqliteDatabase database =
    new SqliteDatabase("Data Source=gamebacklog.db");

database.ShowGames();