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
            Title = title;
            Platform = platform;
            State = state;
            Rating = rating;
            PlayTimeHours = playTimeHours;
        }

        private string _title = string.Empty;
        public string Title
        {
            get
            {
                return _title;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Title cannot be empty");

                _title = value;
            }
        }
        
        private int _rating;
        public int Rating
        {
            get
            {
                return _rating;
            }

            private set
            {
                if (value < 0 || value > 10)
                    throw new ArgumentOutOfRangeException(
                        nameof(Rating),
                        "Rating must be between 0 and 10.");

                _rating = value;
            }
        }

        private double _playTimeHours;
        public double PlayTimeHours
        {
            get
            {
                return _playTimeHours;
            }

            private set
            {
                if (double.IsNaN(value) ||
                    double.IsInfinity(value) ||
                    value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                    nameof(PlayTimeHours),
                    "Playtime must be a valid non-negative value.");
                }

                _playTimeHours = value;
            }
        }

        private Platform _platform;
        public Platform Platform
        {
            get
            {
                return _platform;
            }

            private set
            {
                if (!Enum.IsDefined(value))
                    throw new ArgumentOutOfRangeException(nameof(Platform));

                _platform = value;
            }
        }

        private GameState _state;
        public GameState State
        {
            get
            {
                return _state;
            }

            private set
            {
                if (!Enum.IsDefined(value))
                    throw new ArgumentOutOfRangeException(nameof(State));
                
                _state = value;
            }
        }

        public void ChangePlatform(Platform newPlatform)
        {
            if (Platform == newPlatform)
                return;

            Platform = newPlatform;
        }

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