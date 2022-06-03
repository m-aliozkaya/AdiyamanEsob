using AutoMapper;
using Core.Entities.Concrete;
using Entities.Dto;
using Entities.Entity;

namespace Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookDto>()
            .ForMember(dest => dest.AuthorId
                , act => act.MapFrom(src => src.Author.Id))
            .ForMember(dest => dest.AuthorName
                , act => act.MapFrom(src => src.Author.Name))
            .ReverseMap();

        CreateMap<User, UserForLoginDto>().ReverseMap();
        CreateMap<User, UserForRegisterDto>().ReverseMap();
    }
}