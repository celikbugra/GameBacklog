using System.Runtime.CompilerServices;

namespace GameBacklog.Cli
{
    internal class GameLibrary
    {
        private List<Game> _games = new List<Game>();

        public void AddGame(Game game)
        {
            if (_games.Contains(game))
                return;

            _games.Add(game);
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
                Console.WriteLine(game.Title);
            }
        }

        public void FindGameByTitle(string title)
        {
            foreach (Game game in _games)
            {
                if (title == game.Title)
                {
                    Console.WriteLine(title);
                    return;
                }

                else
                {
                    Console.WriteLine("does not exist");
                    return;
                }
            }
        }

        public void ShowAllGameDetails()
        {
            foreach(Game game in _games)
            {
                Console.WriteLine($"{game.Title} " +
                                  $"| {game.Platform} " +
                                  $"| {game.State} " +
                                  $"| Rating: {game.Rating} " +
                                  $"| Playtime: {game.PlayTimeHours}h");
            }
        }
    }
}