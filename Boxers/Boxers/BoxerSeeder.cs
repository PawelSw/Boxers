using Boxers.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Boxers
{
    public class BoxerSeeder
    {
        private readonly BoxerDbContext _dbContext;

        public BoxerSeeder(BoxerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Boxers.Any())
                {
                    var boxers = GetBoxers();
                    _dbContext.Boxers.AddRange(boxers);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Boxer> GetBoxers()
        {
            var boxers = new List<Boxer>()
            {
                new Boxer()
                {
                    Name = "Mike Tyson",
                    Weight = 99,
                    Wins = 55,
                    Losts = 6,
                    Draws = 0,
                    Achievements = new List<Achievement>()
                    {
                        new Achievement()
                        {
                            Description = "Golden Gloves NY 1979 ",
                        },

                        new Achievement()
                        {
                            Description = "Golden Gloves Miami 1980",
                        },
                    },
                    Trainer = new Trainer()
                    {
                        FullName = "Cus D'Amato",
                    }
                },
                new Boxer()
                {
                    Name = "Lennox Lewis",
                    Weight = 115,
                    Wins = 41,
                    Losts = 2,
                    Draws = 1,
                    Achievements = new List<Achievement>()
                    {
                        new Achievement()
                        {
                            Description = "Olympics Golden Medalist Seul 1988 ",
                        },

                        new Achievement()
                        {
                            Description = "Golden Gloves Miami 1982",
                        },
                    },
                    Trainer = new Trainer()
                    {
                        FullName = "Emanuel Steward",
                    },
                }
            };
            return boxers;
        }
    }
}
