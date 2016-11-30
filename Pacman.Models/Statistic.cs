using System;
using System.ComponentModel.DataAnnotations;

namespace Pacman.Models
{
    public class Statistic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public User User { get; set; }
        public int UserId { get; set; }

        [Required]
        public Level Level { get; set; }
        public int LevelId { get; set; }

        public DateTime PlayGameDate { get; set; }

        public DateTime? EndGameDate { get; set; }
    }
}