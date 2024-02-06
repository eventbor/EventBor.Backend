using AutoMapper;
using EventBor.Backend.Domain.Entities;
using EventBor.Backend.Application.DTOs.Events;
using EventBor.Backend.Application.DTOs.Categories;

namespace EventBor.Backend.Application.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        // Event
        CreateMap<Event, EventForResultDto>().ReverseMap();
        CreateMap<Event, EventForUpdateDto>().ReverseMap();
        CreateMap<Event, EventForCreationDto>().ReverseMap();

        // Category
        CreateMap<Category, CategoryForResultDto>().ReverseMap();
        CreateMap<Category, CategoryForUpdateDto>().ReverseMap();
        CreateMap<Category, CategoryForCreationDto>().ReverseMap();

    }
}
