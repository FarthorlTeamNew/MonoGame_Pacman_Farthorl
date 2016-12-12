using System;
using System.Collections.Generic;
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

        public User()
        {
            this.Friends = new HashSet<User>();
            this.Statistics = new HashSet<Statistic>();
        }

        [Key]
        public int Id { get; protected set; }

        [Required]
        public string FirstName { get; protected set; }

        [Required]
        public string LastName { get; protected set; }

        public DateTime? BurthDate { get; protected set; }

        public virtual Country Country { get; protected set; }
        public int CountryId { get; protected set; }
        
        public virtual City City { get; protected set; }
        public int CityId { get; protected set; }

        public ICollection<Statistic> Statistics { get; set; }

        public virtual PlayerStatistic PlayerStatistic { get; set; }

        public virtual ICollection<User> Friends { get; set; }
    }
}