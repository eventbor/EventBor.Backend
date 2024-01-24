using AutoMapper;
using EventBor.Backend.Application.DTOs.Categories;
using EventBor.Backend.Domain.Entities;

namespace EventBor.Backend.Application.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        // Category
        CreateMap<Category, CategoryForResultDto>().ReverseMap();
        CreateMap<Category, CategoryForUpdateDto>().ReverseMap();
        CreateMap<Category, CategoryForCreationDto>().ReverseMap();
    }
}
