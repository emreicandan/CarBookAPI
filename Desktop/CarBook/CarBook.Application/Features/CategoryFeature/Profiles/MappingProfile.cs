using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.CategoryFeature.Commands;
using CarBook.Application.Features.CategoryFeature.DTOs;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CategoryFeature.Profiles;

    public class MappingProfile:Profile
    {
        public MappingProfile(){

            CreateMap<Category,AddedCategoryDto>();
            CreateMap<Category,UpdatedCategoryDto>();
            CreateMap<Category,GetCategoryListDto>();
            CreateMap<Category,CategoryGetByIdDto>();

            CreateMap<AddCategoryCommand,Category>();
            CreateMap<UpdateCategoryCommand,Category>();
        }
    }
