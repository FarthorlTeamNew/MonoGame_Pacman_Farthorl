using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pacman.Models
{
    public class Level
    {
        private ICollection<LevelCoordinate> coordinates;
        public Level()
        {
            this.coordinates = new HashSet<LevelCoordinate>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? NumbersOfGhost { get; set; }

        public int? NumbersOfPoint { get; set; }

        public int? NumbersOfFruit { get; set; }

        public virtual ICollection<LevelCoordinate> LevelCoordinates
        {
            get { return this.coordinates; }
            set { this.coordinates = value; }
        }
    }
}