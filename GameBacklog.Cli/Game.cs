using GameBacklog.Cli.Enums;

namespace GameBacklog.Cli
{
    internal class Game
    {
        public Game(
            string title,
            Platform platform,
            GameState state,
            int rating,
            double playTimeHours)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty.");

            if (rating < 0 || rating > 10)
                throw new ArgumentOutOfRangeException(
                    nameof(rating),
                    "Rating must be between 0 and 10.");

            if (double.IsNaN(playTimeHours) ||
                double.IsInfinity(playTimeHours) ||
                playTimeHours < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(playTimeHours),
                    "Playtime must be a valid positive value.");
            }

            Title = title;
            Platform = platform;
            State = state;
            Rating = rating;
            PlayTimeHours = playTimeHours;
        }

        public string Title { get; private set; }
        public Platform Platform { get; private set; }
        public GameState State { get; private set; }
        public int Rating { get; private set; }
        public double PlayTimeHours { get; private set; }

        public void ChangeGameState(GameState newState)
        {
            if (State == newState)
                return;

            State = newState;
        }

        public void ChangeRating(int newRating)
        {
            if (newRating < 0 || newRating > 10)
                return;

            if (Rating == newRating)
                return;

            Rating = newRating;
        }

        public void AddPlayTime(double hours)
        {
            if (double.IsNaN(hours) ||
                double.IsInfinity(hours) ||
                hours <= 0)
            {
                return;
            }

            PlayTimeHours += hours;
        }
    }
}