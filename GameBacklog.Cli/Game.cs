using GameBacklog.Cli.Enums;

namespace GameBacklog.Cli
{
    internal class Game
    {
        public Game(string title,
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
            if (Rating == newRating)
                return;

            if (newRating < 0 || newRating > 10)
                return;

            Rating = newRating;
        }

        public void AddPlayTime(double hours)
        {
            if (hours <= 0)
                return;

            PlayTimeHours += hours;
        }
    }
}