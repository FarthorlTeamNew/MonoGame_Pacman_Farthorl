namespace Pacman.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PlayerStatistic
    {
        [Key]
        public int Id { get; set; }

        public int? PlayerPointsEaten { get; set; }

        public int? PlayerFruitEatenCount { get; set; } 

        public int? PlayerGhostsEatenCount { get; set; }

        public int? PlayerGhostkillersEaten { get; set; }

        public int? HardLevelsCompleted { get; set; }

        public int? EasyLevelsCompleted { get; set; }

        public int? PlayerTimesDied { get; set; }

        public virtual User User { get; set; }
    }
}
