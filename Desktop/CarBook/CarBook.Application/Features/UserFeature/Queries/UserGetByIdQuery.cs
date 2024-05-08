using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.UserFeature.DTOs;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.UserFeature.Queries;

    public class UserGetByIdQuery(int id):IRequest<UserGetByIdDto>
    {
        public int Id { get; set; } = id;

    public class Handler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<UserGetByIdQuery, UserGetByIdDto>
    {
        public async Task<UserGetByIdDto> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(await userRepository.GetAsync(u=> u.Id == request.Id));

            return mapper.Map<UserGetByIdDto>(user);
        }
    }
}
