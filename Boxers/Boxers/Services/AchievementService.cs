using AutoMapper;
using Boxers.Entities;
using Boxers.Exceptions;
using Boxers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Boxers.Services
{
    public interface IAchievementService
    {
        int Create(int boxerid, CreateAchievementDto dto);
        AchievementDto GetById(int boxerId, int achievementId);
        List<AchievementDto> GetAll(int boxerId);
        void RemoveAllAchievements(int boxerId);


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
            var boxer = GetBoxerById(boxerid);
            var achievementEntity = _mapper.Map<Achievement>(dto);
            achievementEntity.BoxerId = boxerid;
            _dbcontext.Achievements.Add(achievementEntity);
            _dbcontext.SaveChanges();
            return achievementEntity.Id;
        }
        public AchievementDto GetById(int boxerId, int achievementId)
        {
            var boxer = GetBoxerById(boxerId);
            if (boxer == null) return null;

            var achievement = _dbcontext.Achievements.FirstOrDefault(x => x.Id == achievementId);
            if (achievement == null || achievement.BoxerId != boxerId) return null;

            var achievementDto = _mapper.Map<AchievementDto>(achievement);
            return achievementDto;
        }
        public List<AchievementDto> GetAll(int boxerId)
        {
            //var boxer = _dbcontext
            //    .Boxers
            //    .Include(x => x.Achievements)
            //    .FirstOrDefault(x => x.Id == boxerId);
            var boxer = GetBoxerById(boxerId);
            //if (boxer == null) return null;

            var achievementDto = _mapper.Map<List<AchievementDto>>(boxer.Achievements);
            return achievementDto;
        }

        public void RemoveAllAchievements(int boxerId)
        {
            var boxer = GetBoxerById(boxerId);
            _dbcontext.RemoveRange(boxer.Achievements);
            _dbcontext.SaveChanges();
         
        }


        private Boxer GetBoxerById(int boxerId)
        {
            var boxer = _dbcontext
              .Boxers
              .Include(x => x.Achievements)
              .FirstOrDefault(x => x.Id == boxerId);
            if (boxer == null) return null;

            return boxer;
        }
    }
}
