using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.UserFeature.DTOs;
using CarBook.Application.Repository.Services;
using CarBook.Application.Utilities;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.UserFeature.Commands;

    public class UpdateUserCommand:IRequest<UpdatedUserDto>
    {
        public int Id { get; set; }

        public string UserName { get; set;}

        public string Password { get; set;}

        public int RoleId { get; set; }

    public class Handler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<UpdateUserCommand, UpdatedUserDto>
    {
        public async Task<UpdatedUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(await userRepository.GetAsync(u=>u.Id == request.Id)).MapWithSource(request);

            var updatedUser = await userRepository.UpdateAsync(user);

            return mapper.Map<UpdatedUserDto>(updatedUser);
        }
    }
}
