using GameBacklog.Cli.Core;
using GameBacklog.Cli.Enums;
using GameBacklog.Cli.Helpers;

namespace GameBacklog.Cli;

internal class ConsoleMenu
{
    private readonly GameLibrary _library;
    private bool _exitProgram;

    public ConsoleMenu(GameLibrary library)
    {
        _library = library;
    }

    public void Run()
    {
        while (!_exitProgram)
        {
            ShowMenu();

            string userInputText = Console.ReadLine()!;

            if (!int.TryParse(userInputText, out int userInputNumber))
            {
                ConsoleHelper.TypeWriterLine("Enter a valid number.");
                Console.WriteLine();
                continue;
            }

            switch (userInputNumber)
            {
                case 1:
                    ShowGames();
                    break;

                case 2:
                    AddGame();
                    break;

                case 3:
                    FindGame();
                    break;

                case 4:
                    UpdateGame();
                    break;

                case 5:
                    RemoveGame();
                    break;

                case 6:
                    _exitProgram = true;
                    break;

                default:
                    ConsoleHelper.TypeWriterLine("Unknown menu option.");
                    break;
            }

            Console.WriteLine();
        }

        ConsoleHelper.TypeWriterLine("Goodbye.");
    }

    private void AddGame()
    {
        Console.WriteLine();
        ConsoleHelper.TypeWriterLine("===== Add Game =====");
        Console.WriteLine();

        Console.Write("Title: ");
        string title = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(title))
        {
            ConsoleHelper.TypeWriterLine("Title cannot be empty.");
            return;
        }


        Console.WriteLine();
        ConsoleHelper.TypeWriterLine(
            "Available Platforms:",
            Config.FastTypeWriterDelayMs);

        foreach (Platform platformOption in Enum.GetValues<Platform>())
        {
            ConsoleHelper.TypeWriterLine(
                $"{(int)platformOption}: {platformOption}",
                Config.FastTypeWriterDelayMs);
        }

        Console.Write("Choose Platform: ");
        string platformText = Console.ReadLine()!;

        if (!int.TryParse(platformText, out int platformNumber) ||
            !Enum.IsDefined(typeof(Platform), platformNumber))
        {
            ConsoleHelper.TypeWriterLine("Enter a valid platform.");
            return;
        }

        Platform platform = (Platform)platformNumber;


        Console.WriteLine();
        ConsoleHelper.TypeWriterLine(
            "Available States:",
            Config.FastTypeWriterDelayMs);

        foreach (GameState stateOption in Enum.GetValues<GameState>())
        {
            ConsoleHelper.TypeWriterLine(
                $"{(int)stateOption}: {stateOption}",
                Config.FastTypeWriterDelayMs);
        }

        Console.Write("Choose State: ");
        string gameStateText = Console.ReadLine()!;

        if (!int.TryParse(gameStateText, out int gameStateNumber) ||
            !Enum.IsDefined(typeof(GameState), gameStateNumber))
        {
            ConsoleHelper.TypeWriterLine("Enter a valid state.");
            return;
        }

        GameState state = (GameState)gameStateNumber;


        Console.WriteLine();
        Console.Write("Rating (0-10): ");
        string ratingText = Console.ReadLine()!;

        if (!int.TryParse(ratingText, out int rating) ||
            rating < 0 ||
            rating > 10)
        {
            ConsoleHelper.TypeWriterLine("Enter a valid rating.");
            return;
        }


        Console.Write("Hours Played: ");
        string playTimeText = Console.ReadLine()!;

        if (!double.TryParse(playTimeText, out double playTime) ||
            double.IsNaN(playTime) ||
            double.IsInfinity(playTime) ||
            playTime < 0)
        {
            ConsoleHelper.TypeWriterLine("Enter a valid playtime.");
            return;
        }

        try
        {
            Game userGame = new Game(
                title,
                platform,
                state,
                rating,
                playTime);

            bool gameAdded = _library.AddGame(userGame);

            if (gameAdded)
            {
                ConsoleHelper.TypeWriterLine("Game added successfully.");
            }

            else
            {
                ConsoleHelper.TypeWriterLine("Game already exists.");
            }
        }

        catch (ArgumentException ex)
        {
            ConsoleHelper.TypeWriterLine(ex.Message);
        }

        Console.WriteLine("===============");
    }

    private void FindGame()
    {
        ConsoleHelper.TypeWriterLine("===== Find Game =====");
        Console.WriteLine();

        Console.Write("Title: ");
        string title = Console.ReadLine()!;

        Game? game = _library.FindGameByTitle(title);

        if (game == null)
        {
            ConsoleHelper.TypeWriterLine("Game does not exist.");
            return;
        }
        
        ConsoleHelper.TypeWriterLine(
        $"{game.Title} " +
        $"| {game.Platform} " +
        $"| {game.State} " +
        $"| Rating: {game.Rating} " +
        $"| Playtime: {game.PlayTimeHours}h");

        Console.WriteLine("===============");
    }

    private void UpdateGame()
    {
        ConsoleHelper.TypeWriterLine("===== Update Game =====");
        Console.WriteLine();

        Console.Write("Title: ");
        string title = Console.ReadLine()!;

        Game? game = _library.FindGameByTitle(title);

        if (game == null)
        {
            ConsoleHelper.TypeWriterLine("Game does not exist.");
            return;
        }

        ShowUpdateMenu();

        string updateOptionText = Console.ReadLine()!;

        if (!int.TryParse(updateOptionText, out int updateOptionNumber))
        {
            ConsoleHelper.TypeWriterLine("Enter a valid option.");
            return;
        }

        switch (updateOptionNumber)
        {
            case 1:
                ChangePlatform(game);
                break;

            case 2:
                ChangeGameState(game);
                return;

            case 3:
                ChangeRating(game);
                break;

            case 4:
                AddPlaytime(game);
                break;

            case 5:
                return;

            default:
                ConsoleHelper.TypeWriterLine("Unknown update option.");
                break;
        }

        Console.WriteLine("===============");
    }

    private void ChangePlatform(Game game)
    {
        ConsoleHelper.TypeWriterLine("Available Platforms:");

        
        foreach (Platform platformOption in Enum.GetValues<Platform>())
        {
            ConsoleHelper.TypeWriterLine(
                $"{(int)platformOption}: {platformOption}",
                Config.FastTypeWriterDelayMs);
        }

        Console.Write("Choose new Platform: ");
        string newPlatformText = Console.ReadLine()!;

        if (!int.TryParse(newPlatformText, out int newPlatformNumber) ||
            !Enum.IsDefined(typeof(Platform), newPlatformNumber))
        {
            ConsoleHelper.TypeWriterLine("Enter a valid state.");
            return;
        }

        Platform newPlatform = (Platform)newPlatformNumber;

        game.ChangePlatform(newPlatform);

        ConsoleHelper.TypeWriterLine("Platform updated successfully.");
    }

    private void ChangeGameState(Game game)
    {
        ConsoleHelper.TypeWriterLine("Available States");
        Console.WriteLine();

        foreach(GameState stateOption in Enum.GetValues<GameState>())
        {
            ConsoleHelper.TypeWriterLine(
            $"{(int)stateOption}: {stateOption}",
            Config.FastTypeWriterDelayMs);
        }

        Console.Write("Choose new State: ");
        string newStateText = Console.ReadLine()!;

        if (!int.TryParse(newStateText, out int newStateNumber) ||
            !Enum.IsDefined(typeof(GameState), newStateNumber))
        {
            ConsoleHelper.TypeWriterLine("Enter a valid platform.");
            return;
        }

        GameState newState = (GameState)newStateNumber;

        game.ChangeGameState(newState);

        ConsoleHelper.TypeWriterLine("State updated successfully.");
    }

    private void ChangeRating(Game game)
    {
        ConsoleHelper.TypeWriterLine("Rating (0 - 10)");
        string newRatingText = Console.ReadLine()!;

        if (!int.TryParse(newRatingText, out int newRatingNumber) ||
            newRatingNumber < 0 ||
            newRatingNumber > 10)
        {
            ConsoleHelper.TypeWriterLine("Enter a valid rating.");
            return;
        }

        game.ChangeRating(newRatingNumber);

        ConsoleHelper.TypeWriterLine("Rating updated successfully.");
    }

    private void AddPlaytime(Game game)
    {
        ConsoleHelper.TypeWriterLine("Add playtime");
        string newPlayTimeText = Console.ReadLine()!;

        if (!double.TryParse(newPlayTimeText, out double newPlayTimeNumber) ||
            double.IsNaN(newPlayTimeNumber) ||
            double.IsInfinity(newPlayTimeNumber) ||
            newPlayTimeNumber <= 0)
        {
            ConsoleHelper.TypeWriterLine("Enter a valid positive playtime.");
            return;
        }

        game.AddPlayTime(newPlayTimeNumber);

        ConsoleHelper.TypeWriterLine("Playtime added successfully.");
    }

    private void RemoveGame()
    {
        ConsoleHelper.TypeWriterLine("===== Remove Game =====");
        Console.WriteLine();

        Console.Write("Title: ");
        string title = Console.ReadLine()!;

        Game? game = _library.FindGameByTitle(title);

        if (game == null)
        {
            ConsoleHelper.TypeWriterLine("Game does not exist.");
            return;
        }

        _library.RemoveGame(game);

        ConsoleHelper.TypeWriterLine("Game removed successfully.");

        Console.WriteLine("===============");
    }

    private void ShowGames()
    {
        Console.WriteLine();
        Console.WriteLine("===== Games =====");

        _library.ShowGames();

        Console.WriteLine("===============");
        Console.WriteLine();
    }

    private void ShowMenu()
    {
        Console.WriteLine("===== Menu =====");

        Console.WriteLine("1: Show all games");
        Console.WriteLine("2: Add game");
        Console.WriteLine("3: Find game");
        Console.WriteLine("4: Update game");
        Console.WriteLine("5: Remove game");
        Console.WriteLine("6: Exit");
        
        Console.Write("Choose option: ");
    }

    private void ShowUpdateMenu()
    {
        Console.WriteLine("1: Platform");
        Console.WriteLine("2: State");
        Console.WriteLine("3: Rating");
        Console.WriteLine("4: Add playtime");
        Console.WriteLine("5: Cancel");

        Console.Write("Choose option: ");
    }
}