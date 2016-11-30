using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace Pacman.Models
{
    public class Level
    {
        private ICollection<LevelCoordinates> coordinates;
        private ICollection<User> users; 
        public Level()
        {
            this.coordinates = new HashSet<LevelCoordinates>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? NumbersOfGhost { get; set; }

        public int? NumbersOfPoint { get; set; }

        public int? NumbersOfFruit { get; set; }

        public ICollection<LevelCoordinates> LevelCoordinates
        {
            get { return this.coordinates; }
            set { this.coordinates = value; }
        }

        public ICollection<User> Users {
            get { return this.users; }
            set { this.users = value; }
        }


    }
}