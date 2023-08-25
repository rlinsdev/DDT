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
            // CreateMap<Person, PersonReadDto>()
            //     .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.YearsAlive)); // Map propert different names

            CreateMap<Person, PersonReadDto>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom<AgeResolver>()); // Map propert different names

            CreateMap<PersonCreateDto, Person>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(
                // src => src.FirstName + " " + src.LastName));   // Map First + Last name to FullName
                new FullNameResolver()!))   // Map First + Last name to FullName
                .ForMember(dest => dest.House, opt => opt.NullSubstitute("HufflePuff")); // Null Subistitution

            CreateMap<PersonUpdateDto, Person>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(
                src => src.FirstName + " " + src.LastName));   // Map First + Last name to FullName

            CreateMap<string, int>().ConvertUsing<IntTypeConverter>();

        }
    }
}