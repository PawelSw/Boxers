using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Boxers.Models
{
    public class CreateBoxerDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Precision(3)]
        public int Weight { get; set; }
       
        public int Wins { get; set; }
        public int Losts { get; set; }
        public int Draws { get; set; }
        [Required]
        [MaxLength(50)]
        public string Trainer { get; set; }
    }
}
