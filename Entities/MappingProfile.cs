using AutoMapper;
using Core.Entities.Concrete;
using Entities.Dto;

namespace Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserForLoginDto>().ReverseMap();
        CreateMap<User, UserForRegisterDto>().ReverseMap();
    }
}