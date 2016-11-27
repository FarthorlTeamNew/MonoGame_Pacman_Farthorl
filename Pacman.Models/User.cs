using System;
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

        [Email]
        public string Email { get; set; }

        public string SessionId { get; set; }

    }
}