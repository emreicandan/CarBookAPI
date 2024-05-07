using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.ContactFeature.Commands;
using CarBook.Application.Features.ContactFeature.DTOs;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.ContactFeature.Profiles;

    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Contact , AddedContactDto>();
            CreateMap<Contact , UpdatedContactDto>();
            CreateMap<Contact , GetContactListDto>();
            CreateMap<Contact , ContactGetByIdDto>();

            CreateMap<AddContactCommand , Contact>();
            CreateMap<UpdateContactCommand , Contact>();
        }
    }
