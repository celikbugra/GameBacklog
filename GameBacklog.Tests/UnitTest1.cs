using GameBacklog.Cli;
using GameBacklog.Cli.Enums;
using Xunit.Sdk;

namespace GameBacklog.Tests;

public class GameTests
{
    [Fact]
    public void Constructor_WithValidValues_SetsProperties()
    {
        Game game = new Game(
            "The Witcher 3",
            Platform.PC,
            GameState.Playing,
            10,
            100);

        Assert.Equal("The Witcher 3", game.Title);
        Assert.Equal(Platform.PC, game.Platform);
        Assert.Equal(GameState.Playing, game.State);
        Assert.Equal(10, game.Rating);
        Assert.Equal(100, game.PlayTimeHours);
    }

    [Fact]
    public void Constructor_WithRatingAboveTen_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            new Game(
                "The Witcher 3",
                Platform.PC,
                GameState.Playing,
                11,
                100);
        });
    }

    [Fact]
    public void Constructor_WithPlayTimeLessZero_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            new Game(
                "The Witcher 3",
                Platform.PC,
                GameState.Playing,
                10,
                -1);
        });
    }

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

        Assert.NotNull(foundGame);
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
}