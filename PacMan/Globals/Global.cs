namespace Pacman.Globals
{
    using System.Diagnostics;
    using Enums;

    public static class Global
    {
        public const string LevelPath = @"DataFiles\Levels\Labirint2.txt";
        public const int quad_Width = 32;
        public const int quad_Height = 32;
        public const int Screen_Width = 768;
        public const int Screen_Height = 455;
        public const int XMax = 24;
        public const int YMax = 13;
        public const int PacmanSpeed = 4;
        public const int DefaultGhostSpeed = 2;
        public const int TimePokeball = 7000;
        public const int TimePikachu = 13000;
        public const int TimeDrunk = 5000;
        public const int TimeHungryGhosts = 4000;
        public static Stopwatch GhostKillerTimer;
        public static Stopwatch PeachTimer;
        public static Stopwatch HungryGhosts;
        public static DifficultyEnumerable Difficulty;
    }
}