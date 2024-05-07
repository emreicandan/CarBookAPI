using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.CarFeatureFeature.Commands;
using CarBook.Application.Features.CarFeatureFeature.DTOs;

namespace CarBook.Application.Features.CarFeatureFeature.Profiles;

    public class MappingProfile:Profile
    {
        public MappingProfile(){

            CreateMap<Domain.Entities.CarFeature , AddedCarFeatureDto>();
            CreateMap<Domain.Entities.CarFeature , AddedCarFeatureDto>();
            CreateMap<Domain.Entities.CarFeature , AddedCarFeatureDto>();
            CreateMap<Domain.Entities.CarFeature , AddedCarFeatureDto>();

            CreateMap<AddCarFeatureCommand , Domain.Entities.CarFeature>();
            CreateMap<UpdateCarFeatureCommand , Domain.Entities.CarFeature>();
        }
    }
