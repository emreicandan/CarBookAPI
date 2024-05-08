using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.UserFeature.Commands;

    public class DeleteUserCommand(int id):IRequest<bool>
    {
        public int Id { get; set; } = id;

    public class Handler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<DeleteUserCommand, bool>
    {
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(await userRepository.GetAsync(u=>u.Id == request.Id));

            await userRepository.DeleteAsync(user);

            return true;
        }
    }
}