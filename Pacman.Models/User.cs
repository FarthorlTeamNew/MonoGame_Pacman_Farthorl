using System;
using System.ComponentModel.DataAnnotations;

namespace Pacman.Models
{
    public class User
    {
        public enum Roles
        {
            user,
            admin
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime? BurthDate { get; set; }

        public virtual Country Country { get; set; }
        public int CountryId { get; set; }
        
        public virtual City City { get; set; }
        public int CityId { get; set; }

        public virtual PlayerStatistic PlayerStatistic { get; set; }
    }
}