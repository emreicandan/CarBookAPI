using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Enums;
using CarBook.Application.Features.UserFeature.DTOs;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.UserFeature.Commands
{
    public class AddUserCommand:IRequest<AddedUserDto>
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        [JsonIgnore]
        public int RoleId { get; set; } = (int)RoleNames.Member;

        public class Handler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<AddUserCommand, AddedUserDto>
        {
            public async Task<AddedUserDto> Handle(AddUserCommand request, CancellationToken cancellationToken)
            {
                var user = mapper.Map<User>(request);

                var addedUser =  await userRepository.AddAsync(user);

                return mapper.Map<AddedUserDto>(addedUser);
            }
        }

    }
}