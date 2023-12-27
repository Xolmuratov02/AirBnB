using AirBnB.Api.Models.Dtos;
using AirBnB.Domain.Entities;
using AutoMapper;

namespace AirBnB.Api.Mappers;

public class CityMapper : Profile
{
    public CityMapper()
    {
        CreateMap<City, CityDto>().ReverseMap();
    }
}