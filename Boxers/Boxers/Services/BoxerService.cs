using AutoMapper;
using Boxers.Entities;
using Boxers.ErrorHandling;
using Boxers.Exceptions;
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
        bool Update(UpdateBoxerDto dto, int id);
    }
    public class BoxerService : IBoxerService
    {
        private readonly BoxerDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<BoxerService> _logger;
        public BoxerService(BoxerDbContext dbContext, IMapper mapper, ILogger<BoxerService> logger) 
        {
            _dbContext = dbContext;        
            _mapper = mapper;
            _logger = logger;
        }
        public BoxerDto GetById( int  id )
        {
            var boxer = _dbContext
                 .Boxers
                 .Include(x => x.Trainer)
                 .Include(x => x.Achievements)
                 .FirstOrDefault(x => x.Id == id);

            if (boxer == null) 
                throw new NotFoundException("Boxer not found");

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
                 
            if (boxer == null) 
                throw new NotFoundException("Boxer not found");
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
            _logger.LogError($"Boxer with id: {id} DELETE action invoked");
            var boxer = _dbContext
                .Boxers.FirstOrDefault(x => x.Id == id);
            if ( boxer == null )
                throw new NotFoundException("Boxer not found");
            _dbContext.Boxers.Remove(boxer);
            _dbContext.SaveChanges();
            return true;
        }
        public bool Update(UpdateBoxerDto dto, int id)
        {
            var boxer = _dbContext
                .Boxers.FirstOrDefault(x => x.Id == id);
            if (boxer == null)
                throw new NotFoundException("Boxer not found");

            boxer.Weight = dto.Weight;
            boxer.Wins = dto.Wins;
            boxer.Losts = dto.Losts;

            _dbContext.SaveChanges();

            return true;
        }
    }
}
