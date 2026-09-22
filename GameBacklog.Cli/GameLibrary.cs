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

        public IReadOnlyList<Game> GetAllGames()
        {
            return _games;
        }

        public Game? FindGameByTitle(string title)
        {
            foreach (Game game in _games)
            {
                if (string.Equals(
                    title,
                    game.Title,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return game;
                }
            }

            return null;
        }
    }
}