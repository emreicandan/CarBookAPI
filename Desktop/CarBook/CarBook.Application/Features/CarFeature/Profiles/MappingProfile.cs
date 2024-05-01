using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.CarFeature.Commands;
using CarBook.Application.Features.CarFeature.DTOs;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CarFeature.Profiles;

    public class MappingProfile:Profile
    {
        public MappingProfile(){

            CreateMap<Car, AddedCarDto>();
            CreateMap<Car, UpdatedCarDto>();
            CreateMap<Car, CarGetByIdDto>();
            CreateMap<Car, GetCarListDto>();

            CreateMap<AddCarCommand , Car>();
            CreateMap<UpdateCarCommand, Car>();
        }
    }
