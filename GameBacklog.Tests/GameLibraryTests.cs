using GameBacklog.Cli;
using GameBacklog.Cli.Enums;

namespace GameBacklog.Tests;

public class GameLibraryTests
{
    [Fact]
    public void AddGame_NewGame_ReturnsTrue()
    {
        GameLibrary gameLibrary = new GameLibrary();

        Game residentEvil = new Game("Resident Evil",
                                Platform.PC,
                                GameState.Completed,
                                10,
                                50);

        bool result = gameLibrary.AddGame(residentEvil);

        Assert.True(result);
    }

    [Fact]
    public void AddGame_DuplicateGame_ReturnsFalse()
    {
        GameLibrary gameLibrary = new();
        Game botw = new("BOTW", Platform.Switch, GameState.Playing, 9, 35);
        Game botws = new("BotW", Platform.Switch, GameState.Playing, 9, 35);

        gameLibrary.AddGame(botw);

        bool result = gameLibrary.AddGame(botws);

        Assert.False(result);
    }

    [Fact]
    public void FindGameByTitle_ExistingGame_ReturnsGame()
    {
        GameLibrary gameLibrary = new();
        Game batman = new("Batman",
                    Platform.Playstation,
                    GameState.Completed,
                    10,
                    200);

        gameLibrary.AddGame(batman);

        Game? foundGame = gameLibrary.FindGameByTitle(batman.Title);

        Assert.Same(batman, foundGame);
    }

    [Fact]
    public void FindGameByTitle_UnknownGame_ReturnsNull()
    {
        GameLibrary gameLibrary = new();

                Game outlast = new("Outlast",
                    Platform.PC,
                    GameState.Completed,
                    10,
                    150);

        Game? foundGame = gameLibrary.FindGameByTitle(outlast.Title);

        Assert.Null(foundGame);
    }

    [Fact]
    public void RemoveGame_ExistingGame_RemovesGame()
    {
        GameLibrary gameLibrary = new();

        Game outlast = new("Outlast",
            Platform.PC,
            GameState.Completed,
            10,
            150);

        gameLibrary.AddGame(outlast);

        bool result = gameLibrary.RemoveGame(outlast);

        Assert.True(result);

        Game? foundGame = gameLibrary.FindGameByTitle(outlast.Title);

        Assert.Null(foundGame);
    }

    [Fact]
    public void RemoveGame_UnknownGame_ReturnsFalse()
    {
        GameLibrary gameLibrary = new();

        Game outlast = new("Outlast",
            Platform.PC,
            GameState.Completed,
            10,
            150);

        bool result = gameLibrary.RemoveGame(outlast);

        Assert.False(result);
    }
}