using AirBnB.Api.Models.Dtos;
using AirBnB.Domain.Entities;
using AutoMapper;

namespace AirBnB.Api.Mappers;

public class CountryMapper : Profile
{
    public CountryMapper()
    {
        CreateMap<Country, CountryDto>().ReverseMap();
    }
}