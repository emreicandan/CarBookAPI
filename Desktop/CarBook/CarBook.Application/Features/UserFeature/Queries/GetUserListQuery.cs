using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.UserFeature.DTOs;
using CarBook.Application.Repository.Services;
using MediatR;

namespace CarBook.Application.Features.UserFeature.Queries;

    public class GetUserListQuery:IRequest<IList<GetUserListDto>>
    {
    public class Handler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<GetUserListQuery, IList<GetUserListDto>>
    {
        public async Task<IList<GetUserListDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var users = await userRepository.GetAllAsync();

            return users.Select(u=> mapper.Map<GetUserListDto>(u)).ToList();
        }
    }
    }
