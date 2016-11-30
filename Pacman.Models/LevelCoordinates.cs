using System.ComponentModel.DataAnnotations;

namespace Pacman.Models
{
    public class LevelCoordinates
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Level Level { get; set; }
        public int LevelId { get; set; }

        [Required]
        public int QuadrantX { get; set; }
        [Required]
        public int QuadrantY { get; set; }
        [Required]
        public bool isWall { get; set; }
        [Required]
        public bool isPoint { get; set; }
    }
}