using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.UserFeature.Commands;
using CarBook.Application.Features.UserFeature.DTOs;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.UserFeature.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile(){

            CreateMap<User , AddedUserDto>();
            CreateMap<User , UpdatedUserDto>();
            CreateMap<User , GetUserListDto>();
            CreateMap<User , UserGetByIdDto>();

            CreateMap<AddUserCommand , User>();
            CreateMap<UpdateUserCommand , User>();
        }
    }
}