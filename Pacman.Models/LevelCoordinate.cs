using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pacman.Models
{
    public class LevelCoordinate
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("LevelId")]
        public virtual Level Level { get; set; }
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