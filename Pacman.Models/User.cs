using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Pacman.Models.Attributes;

namespace Pacman.Models
{
    public class User
    {
        public enum Roles
        {
            user,
            admin
        }

        private ICollection<Level> levels;

        public User()
        {
            this.levels = new HashSet<Level>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime? BurthDate { get; set; }

        public Country Country { get; set; }
        public int CountryId { get; set; }
        
        public City City { get; set; }
        public int CityId { get; set; }

        public ICollection<Level> PlayedLevels {
            get { return this.levels; }
            set { this.levels = value; }
        }

    }
}