namespace Pacman.JsonConverter
{
    using System;
    using Data;
    using Enums;

    class Startup
    {
        static void Main()
        {
            var context = new PacmanContext();

            var topPlayerByType = new TopPlayersByType(context, OrderType.EasyLevelsCompleted, 10);
            Console.WriteLine(topPlayerByType.Message);
            Console.WriteLine(string.Join(Environment.NewLine, topPlayerByType.GetTopPlayers()));
        }
    }
}