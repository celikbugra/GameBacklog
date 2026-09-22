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
                    _library.ShowGames();
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

        if (!int.TryParse(ratingText, out int rating))
        {
            ConsoleHelper.TypeWriterLine("Enter a valid rating.");
            return;
        }


        Console.Write("Hours Played: ");
        string playTimeText = Console.ReadLine()!;

        if (!double.TryParse(playTimeText, out double playTime))
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
                return;

            default:
                ConsoleHelper.TypeWriterLine("Unknown update option.");
                break;
        }
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
            ConsoleHelper.TypeWriterLine("Enter a valid platform.");
            return;
        }

        Platform newPlatform = (Platform)newPlatformNumber;

        game.ChangePlatform(newPlatform);

        ConsoleHelper.TypeWriterLine("Platform updated successfully.");
    }

    private void ShowMenu()
    {
        Console.WriteLine("1: Show all games");
        Console.WriteLine("2: Add game");
        Console.WriteLine("3: Find game");
        Console.WriteLine("4: Update game");
        Console.WriteLine("6: Exit");
        
        Console.Write("Choose option: ");
    }

    private void ShowUpdateMenu()
    {
        Console.WriteLine("1: Platform");
        Console.WriteLine("2: Cancel");

        Console.Write("Choose option: ");
    }
}