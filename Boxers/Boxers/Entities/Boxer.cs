using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Boxers.Entities
{
    public class Boxer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Precision(3)]
        public int Weight { get; set; }
        public int Wins { get; set; }
        public int Losts { get; set; }
        public int Draws { get; set; }
        public int TrainerId { get; set; }
        public virtual Trainer Trainer { get; set; }

        public virtual List<Achievement> Achievements { get; set; }
    }
}
