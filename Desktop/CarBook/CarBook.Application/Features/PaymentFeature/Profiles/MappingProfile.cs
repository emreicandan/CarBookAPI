using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.PaymentFeature.Commands;
using CarBook.Application.Features.PaymentFeature.DTOs;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.PaymentFeature.Profiles;

    public class MappingProfile:Profile
    {
        public MappingProfile(){

            CreateMap<Payment , AddedPaymentDto>();
            CreateMap<Payment , UpdatedPaymentDto>();
            CreateMap<Payment , GetPaymentListDto>();
            CreateMap<Payment , PaymentGetByIdDto>();

            CreateMap<AddPaymentCommand , Payment>();
            CreateMap<UpdatePaymentCommand , Payment>();
        }
    }
