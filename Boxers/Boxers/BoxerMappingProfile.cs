using AutoMapper;
using Boxers.Entities;
using Boxers.Models;

namespace Boxers
{
    public class BoxerMappingProfile : Profile
    {
        public BoxerMappingProfile() 
        {
            CreateMap<Boxer, BoxerDto>()
                .ForMember(m => m.Trainer, c => c.MapFrom(s => s.Trainer.FullName));
                //.ForMember(m => m.Achievements, c => c.MapFrom(s => s.Achievements))
                //.ForMember(m => m.Id, c => c.MapFrom(s => s.Id))
                //.ForMember(m => m.Name, c => c.MapFrom(s => s.Name))
                //.ForMember(m => m.Weight, c => c.MapFrom(s => s.Weight))
                //.ForMember(m => m.Wins, c => c.MapFrom(s => s.Wins))
                //.ForMember(m => m.Losts, c => c.MapFrom(s => s.Losts))             
                //.ForMember(m => m.Draws, c => c.MapFrom(s => s.Draws));

            CreateMap<Achievement, AchievementDto>();
        }
    }
}
