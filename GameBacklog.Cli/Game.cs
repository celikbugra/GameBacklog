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


        public string Title { get; set; }
        public Platform Platform { get; set; }
        public GameState State { get; set; }
        public int Rating { get; set; }
        public double PlayTimeHours { get; set; }
    }
}