
using System.ComponentModel.DataAnnotations.Schema;

namespace Pacman.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        private ICollection<City> cities;

        public Country()
        {
            this.cities = new HashSet<City>();
        }

        [Key]
        public int Id { get; set; }

        [MinLength(2), MaxLength(2)]
        [Index(IsUnique = true)]
        public string ISO2 { get; set; }

        [Required]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [MinLength(3), MaxLength(3)]
        [Index(IsUnique = true)]
        public string ISO3 { get; set; }

        public string InternationRegion { get; set; }

        public virtual ICollection<City> Cities
        {
            get { return this.cities; }
            set { this.cities = value; }
        }
    }
}