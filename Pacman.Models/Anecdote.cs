using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pacman.Models
{
    public class Anecdote
    {
        [Key]
        public int Id { get; set; }

        [Column("NVARCHAR(MAX)")]
        public string AnecdoteNote { get; set; }
    }
}