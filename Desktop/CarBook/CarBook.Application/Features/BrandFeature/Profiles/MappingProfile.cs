

using AutoMapper;
using CarBook.Application.Features.BrandFeature.DTOs;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.BrandFeature.Commands.Queries.DTOs.Profiles;

    public class MappingProfile:Profile
    {
        public MappingProfile(){

            CreateMap<Brand , AddedBrandDto>();
            CreateMap<Brand , UpdatedBrandDto>();
            CreateMap<Brand , GetByIdBrandDto>();
            CreateMap<Brand , BrandListDto>();

            CreateMap<AddBrandCommand , Brand>();
            CreateMap<UpdateBrandCommand , Brand>();
        }
    }
