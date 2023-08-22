using AutoMapper;
using PersonAPI.Dtos;
using PersonAPI.Models;

namespace PersonAPI.Profiles
{
    public class PeopleProfile : Profile
    {
        public PeopleProfile()
        {
            // Source -> Destination
            CreateMap<Person, PersonDto>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.YearsAlive)); // Map propert different names
            
        }

    }
}