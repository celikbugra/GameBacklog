using GameBacklog.Cli;
using GameBacklog.Cli.Enums;

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
    public void ChangeRating_InvalidRating_ThrowsArgumentOutOfRangeException()
    {
        Game outlast = new("Outlast",
            Platform.PC,
            GameState.Completed,
            10,
            150);

        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            outlast.ChangeRating(12);
        });
    }

    [Fact]
    public void AddPlayTime_InvalidHours_ThrowsArgumentOutOfRangeException()
    {
        Game outlast = new(
            "Outlast",
            Platform.PC,
            GameState.Completed,
            10,
            150);

        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            outlast.AddPlayTime(-25);
        });
    }
}