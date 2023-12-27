using AirBnB.Api.Models.Dtos;
using AirBnB.Domain.Entities;
using AutoMapper;

namespace AirBnB.Api.Mappers;

public class ListingCategoryMapper : Profile
{
    public ListingCategoryMapper()
    {
        CreateMap<ListingCategory, ListingCategoryDto>()
            .ForMember(dest => dest.ImageUrl, opt => opt.ConvertUsing<StorageFilePathToUrlConverter, StorageFile>(src => src.ImageStorageFile));
    }
}