namespace Pacman.JsonConverter
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Enums;
    using ViewModels;

    public class TopPlayersByType : IHighscore<TopPlayerDto>
    {
        private readonly PacmanContext context;
        private readonly int numberOfTopPlayers;
        private readonly OrderType orderType;

        public TopPlayersByType(PacmanContext pacmanContext, OrderType orderType, int numberOfTopPlayers)
        {
            this.context = pacmanContext;
            this.numberOfTopPlayers = numberOfTopPlayers;
            this.orderType = orderType;
        }

        public string Message => $"Top {this.numberOfTopPlayers} players by eaten points!";

        public IEnumerable<TopPlayerDto> GetTopPlayers()
        {
            var highscores = this.context.PlayerStatistics.OrderBy(p => p.UserId);

            switch (this.orderType)
            {
                case OrderType.PlayerPointsEaten:
                    highscores = highscores.OrderByDescending(s => s.PlayerPointsEaten);
                    break;
                case OrderType.EasyLevelsCompleted:
                    highscores = highscores.OrderByDescending(s => s.EasyLevelsCompleted);
                    break;
                case OrderType.PlayerTimesDied:
                    highscores = highscores.OrderByDescending(s => s.PlayerTimesDied);
                    break;
            }

            int counter = 1;
            var resultHighscores = highscores
                                        .Take(this.numberOfTopPlayers)
                                        .ToList()
                                        .Select(ps => new TopPlayerDto()
                                        {
                                            Place = counter++,
                                            PlayerName = ps.User.FirstName + " " + ps.User.LastName,
                                            EatenPoints = ps.PlayerPointsEaten,
                                            EasyLevelsCompleted = ps.EasyLevelsCompleted,
                                            TimesDied = ps.PlayerTimesDied
                                        });

            return resultHighscores; 
        }
    }
}