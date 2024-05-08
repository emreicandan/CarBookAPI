using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.UserFeature.DTOs;
using CarBook.Application.Repository.Services;
using MediatR;

namespace CarBook.Application.Features.UserFeature.Queries;

    public class GetCheckUserQuery:IRequest<GetCheckUserDto>
    {
        public string UserName { get; set; }

        public string Password { get; set; }

    public class Handler(IUserRepository userRepository, IRoleRepository roleRepository) : IRequestHandler<GetCheckUserQuery, GetCheckUserDto>
    {
        public async Task<GetCheckUserDto> Handle(GetCheckUserQuery request, CancellationToken cancellationToken)
        {
            var values = new GetCheckUserDto();
            var user = await userRepository.GetAsync(u => u.UserName == request.UserName && u.Password == request.Password);

            if (user == null){
                values.IsExist = false;
            }
            else{
                values.IsExist = true;
                values.Id = user.Id;
                values.Role = (await roleRepository.GetAsync(r => r.Id == user.RoleId)).Name;
                values.UserName = user.UserName;
            }

            return values;
        }
    }
}
