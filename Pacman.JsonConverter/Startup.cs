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

            var topPlayersCollection =
            TopPlayersByType.Create(OrderType.EasyLevelsCompleted, 10).GetTopScores();
            
            JsonExporter.ExportToJsonFile(topPlayersCollection,"PlayersTopScore");
        }
    }
}