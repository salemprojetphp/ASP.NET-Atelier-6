namespace _.Mappings;

using AutoMapper;
using _.DTOs;
using _.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Configuration des mappings entre modèles et DTOs
        CreateMap<Category, CategoryDTO>().ReverseMap();
    }
}
