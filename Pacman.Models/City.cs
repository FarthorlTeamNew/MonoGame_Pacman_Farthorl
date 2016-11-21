
namespace Pacman.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual Country Country { get; set; }
    }
}