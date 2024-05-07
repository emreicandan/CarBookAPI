using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.CarPaymentFeature.Commands;
using CarBook.Application.Features.CarPaymentFeature.DTOs;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CarPaymentFeature.Profiles;

    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CarPayment , AddedCarPaymentDto>();
            CreateMap<CarPayment , UpdatedCarPaymentDto>();
            CreateMap<CarPayment , GetCarPaymentListDto>();
            CreateMap<CarPayment , CarPaymentGetByIdDto>();

            CreateMap<AddCarPaymentCommand , CarPayment>();
            CreateMap<UpdateCarPaymentCommand , CarPayment>();
        }
    }
