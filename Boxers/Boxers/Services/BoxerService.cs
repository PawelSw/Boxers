using AutoMapper;
using Boxers.Entities;
using Boxers.Models;
using Microsoft.EntityFrameworkCore;

namespace Boxers.Services
{
    public interface IBoxerService
    {
        BoxerDto GetById(int id);
        int Create(CreateBoxerDto dto);
        IEnumerable<BoxerDto> GetAll();
        bool DeleteById(int id);
    }
    public class BoxerService : IBoxerService
    {
        private readonly BoxerDbContext _dbContext;
        private readonly IMapper _mapper;
        public BoxerService(BoxerDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;        
            _mapper = mapper;
        }
        public BoxerDto GetById( int  id )
        {
            var boxer = _dbContext
                 .Boxers
                 .Include(x => x.Trainer)
                 .Include(x => x.Achievements)
                 .FirstOrDefault(x => x.Id == id);
            
            if ( boxer == null )  return null;

            var boxerDto = _mapper.Map<BoxerDto>(boxer);
            return boxerDto;
        }
        public IEnumerable<BoxerDto> GetAll()
        {
            var boxer = _dbContext
                 .Boxers
                 .Include(x => x.Trainer)
                 .Include(x => x.Achievements)
                 .ToList();
                 

            if (boxer == null) return null;

            var boxersDto = _mapper.Map<List<BoxerDto>>(boxer);
            return boxersDto;
        }

        public int Create (CreateBoxerDto dto)
        {
            var boxer = _mapper.Map<Boxer>(dto);
            _dbContext.Boxers.Add(boxer);
            _dbContext.SaveChanges();
            return boxer.Id;

        }

        public bool DeleteById ( int id )
        {
            var boxer = _dbContext
                .Boxers.FirstOrDefault(x => x.Id == id);
            if ( boxer == null ) return false;
            _dbContext.Boxers.Remove(boxer);
            _dbContext.SaveChanges();
            return true;


        }
    }
}
