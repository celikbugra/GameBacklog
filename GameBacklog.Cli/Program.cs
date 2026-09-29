using GameBacklog.Cli;
using GameBacklog.Cli.Data;

SqliteDatabase database =
    new SqliteDatabase("Data Source=gamebacklog.db");

database.Initialize();

GameLibrary library = new GameLibrary();

List<Game> gamesFromDataBase =
    database.GetAllGames();

foreach (Game game in gamesFromDataBase)
{
    library.AddGame(game);
}

ConsoleMenu menu =
    new ConsoleMenu(library, database);

menu.Run();