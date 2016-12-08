namespace Pacman.Globals
{
    public static class GameStatistic
    {
        //Player stats

        public static int PlayerPointsEaten { get; set; }

        public static int PlayerFruitEatenCount { get; set; }

        public static int PlayerGhostsEatenCount { get; set; }

        public static int LevelsCompleted { get; set; }

        public static int PlayerTimesDied { get; set; }

        //Ghosts stats

        public static int NumberOfPointsEatenByGhost { get; set; }

        public static int TimesEatenPacman { get; set; }

        public static void NullifyStats()
        {
            PlayerPointsEaten = 0;
            PlayerFruitEatenCount = 0;
            PlayerGhostsEatenCount = 0;
            LevelsCompleted = 0;
            PlayerTimesDied = 0;
            NumberOfPointsEatenByGhost = 0;
            TimesEatenPacman = 0;
        }

        public static void UpdateStatsToDatabase()
        {
            // Use DataBridge to update the stats of the current player
        }
    }
}