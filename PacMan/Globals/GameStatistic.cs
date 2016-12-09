namespace Pacman.Globals
{
    public static class GameStatistic
    {
        //Player stats

        public static int PlayerPointsEaten { get; set; } //Tested and working

        public static int PlayerFruitEatenCount { get; set; } //Tested and working

        public static int PlayerGhostsEatenCount { get; set; } //Tested and working

        public static int PlayerGhostkillersEaten { get; set; } //Tested and working

        public static int HardLevelsCompleted { get; set; } //Should be working, but cannot test it because it is hard to complete the level indeed :)

        public static int EasyLevelsCompleted { get; set; } //Tested and working

        public static int PlayerTimesDied { get; set; } //Tested and working

        //Ghosts stats

        public static int NumberOfPointsEatenByGhost { get; set; } //Tested and working BUT GHOSTS NEVER STOP EATING POINTS! CHECK TIMERS!

        public static string GhostThatAtePacman { get; set; } //Tested and working, BUT if a player is killed more times during a single login, only the last ghost name is kept? 

        public static void NullifyStats()
        {
            PlayerPointsEaten = 0;
            PlayerFruitEatenCount = 0;
            PlayerGhostsEatenCount = 0;
            HardLevelsCompleted = 0;
            EasyLevelsCompleted = 0;
            PlayerTimesDied = 0;
            NumberOfPointsEatenByGhost = 0;
            GhostThatAtePacman = string.Empty;
        }

        public static void UpdateStatsToDatabase()
        {
            // Use DataBridge to update the stats of the current player
        }
    }
}