using GameBacklog.Cli.Helpers;
using GameBacklog.Cli.Core;

namespace GameBacklog.Cli
{
    internal class GameLibrary
    {
        private readonly List<Game> _games = new List<Game>();

        public bool AddGame(Game game)
        {

            foreach (Game existingGame in _games)
            {
                if (string.Equals(
                    existingGame.Title,
                    game.Title,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }

            _games.Add(game);
            return true;
        }

        public void RemoveGame(Game game)
        {
            if (!_games.Contains(game))
                return;

            _games.Remove(game);
        }

        public void ShowGames()
        {
            foreach (Game game in _games)
            {
                ConsoleHelper.TypeWriterLine(
                    game.Title,
                    Config.FastTypeWriterDelayMs);
            }
        }

        public void FindGameByTitle(string title)
        {
            foreach (Game game in _games)
            {
                if (string.Equals(
                    title,
                    game.Title,
                    StringComparison.OrdinalIgnoreCase))
                {
                    ConsoleHelper.TypeWriterLine(game.Title);
                    return;
                }
            }

            ConsoleHelper.TypeWriterLine("Game does not exist.");
        }

        public void ShowAllGameDetails()
        {
            foreach (Game game in _games)
            {
                ConsoleHelper.TypeWriterLine(
                    $"{game.Title} " +
                    $"| {game.Platform} " +
                    $"| {game.State} " +
                    $"| Rating: {game.Rating} " +
                    $"| Playtime: {game.PlayTimeHours}h");
            }
        }
    }
}