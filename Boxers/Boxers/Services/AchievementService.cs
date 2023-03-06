using AutoMapper;
using Boxers.Entities;
using Boxers.Exceptions;
using Boxers.Models;

namespace Boxers.Services
{
    public interface IAchievementService
    {
        int Create(int boxerid, CreateAchievementDto dto);

    }
    public class AchievementService : IAchievementService
    {
        private readonly BoxerDbContext _dbcontext;
        private readonly IMapper _mapper;
        public AchievementService(BoxerDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;

        }
        public int Create(int boxerid, CreateAchievementDto dto)
        {
            var boxer = _dbcontext.Boxers.FirstOrDefault(x => x.Id == boxerid);
            if (boxer == null) return 0;
         
                  
            var achievementEntity = _mapper.Map<Achievement>(dto);
           achievementEntity.BoxerId = boxerid;
            _dbcontext.Achievements.Add(achievementEntity);
            _dbcontext.SaveChanges();
            return achievementEntity.Id;

        }
    }
}
