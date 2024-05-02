using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.FatureFeature.Commands;
using CarBook.Application.Features.FatureFeature.DTOs;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.FatureFeature.Profiles;

    public class MappingProfile:Profile
    {
        public MappingProfile(){

            CreateMap<Feature,AddedFeatureDto>();
            CreateMap<Feature,UpdatedFeatureDto>();
            CreateMap<Feature,GetFeatureListDto>();
            CreateMap<Feature,FeatureGetByIdDto>();

            CreateMap<AddFeatureCommand,Feature>();
            CreateMap<UpdateFeatureCommand,Feature>();
        }
    }
