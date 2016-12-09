using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pacman.Models
{
    public class Statistic
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }

        [Required]
        public virtual Level Level { get; set; }
        public int LevelId { get; set; }

        public DateTime StartGame { get; set; }
        public DateTime? EndGame { get; set; }
        public TimeSpan? Duration { get; set; }
    }
}