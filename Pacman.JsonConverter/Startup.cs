namespace Pacman.JsonConverter
{
    using System;
    using Converters;
    using Data;
    using Enums;

    class Startup
    {
        static void Main()
        {
            var context = new PacmanContext();

            var topPlayerByType = new TopPlayersByType(context, OrderType.EasyLevelsCompleted, 10);
            var topPlayersCollection = topPlayerByType.GetTopScores();
            JsonExporter.ExportToJsonFile(topPlayersCollection,"PlayersTopScore");
        }
    }
}