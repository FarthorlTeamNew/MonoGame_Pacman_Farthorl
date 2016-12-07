using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pacman.Models
{
    public class LevelCoordinate
    {
        [Key]
        public int Id { get; protected set; }

        [ForeignKey("LevelId")]
        public virtual Level Level { get; protected set; }
        public int LevelId { get; protected set; }

        [Required]
        public int QuadrantX { get; protected set; }
        [Required]
        public int QuadrantY { get; protected set; }
        [Required]
        public bool isWall { get; protected set; }
        [Required]
        public bool isPoint { get; protected set; }
    }
}