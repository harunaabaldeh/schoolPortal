using API.Dtos;
using API.Entities;
using AutoMapper;

namespace API.MappingProfiles;
public class SchoolsProfile : Profile
{
    public SchoolsProfile()
    {
        // Source -> Target
        CreateMap<School, SchoolDto>();
        CreateMap<SchoolDto, School>();
    }
}