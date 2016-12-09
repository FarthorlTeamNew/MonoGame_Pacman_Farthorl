namespace Pacman.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class PlayerStatistic
    {
        public PlayerStatistic()
        {
            PlayerPointsEaten = 0;
            PlayerFruitEatenCount = 0;
            PlayerGhostsEatenCount = 0;
            PlayerGhostkillersEaten = 0;
            HardLevelsCompleted = 0;
            EasyLevelsCompleted = 0;
            PlayerTimesDied = 0;
        }

        [ForeignKey("User")]
        public int Id { get; set; }

        public int PlayerPointsEaten { get; set; }

        public int PlayerFruitEatenCount { get; set; } 

        public int PlayerGhostsEatenCount { get; set; }

        public int PlayerGhostkillersEaten { get; set; }

        public int HardLevelsCompleted { get; set; }

        public int EasyLevelsCompleted { get; set; }

        public int PlayerTimesDied { get; set; }

        public virtual User User { get; set; }
    }
}
