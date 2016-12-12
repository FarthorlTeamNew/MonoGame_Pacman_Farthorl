namespace Pacman.JsonConverter
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Enums;
    using Interfaces;
    using ViewModels;

    public class TopPlayersByType : IHighscore<TopPlayerDto>
    {
        private readonly PacmanContext context;
        private readonly int numberOfTopPlayers;
        private readonly OrderType orderType;
        private string orderTypeString;

        public static TopPlayersByType Create(OrderType orderType, int numberOfTopPlayers)
        {
            return new TopPlayersByType(orderType, numberOfTopPlayers);
        }

        private TopPlayersByType(OrderType orderType, int numberOfTopPlayers)
        {
            this.context = new PacmanContext();
            this.numberOfTopPlayers = numberOfTopPlayers;
            this.orderType = orderType;
            this.OrderTypeString = orderType.ToString();
        }

        public string Message => $"Top {this.numberOfTopPlayers} players by {this.OrderTypeString}!";

        private string OrderTypeString
        {
            get { return this.orderTypeString; }
            set
            {
                if (value == OrderType.PlayerPointsEaten.ToString())
                {
                    this.orderTypeString = "eaten points";
                }
                else if (value == OrderType.EasyLevelsCompleted.ToString())
                {
                    this.orderTypeString = "easy levels completed";
                }
                else if (value == OrderType.PlayerTimesDied.ToString())
                {
                    this.orderTypeString = "times died";
                }
            }
        }


        public IEnumerable<TopPlayerDto> GetTopScores()
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