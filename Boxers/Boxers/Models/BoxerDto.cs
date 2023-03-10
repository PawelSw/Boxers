using Boxers.Entities;
using Microsoft.EntityFrameworkCore;

namespace Boxers.Models
{
    public class BoxerDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [Precision(3)]
        public int Weight { get; set; }
        public int Wins { get; set; }
        public int Losts { get; set; }
        public int Draws { get; set; }

        public string Trainer { get; set; }
        public  virtual List<AchievementDto> Achievements { get; set; }
    }
}
