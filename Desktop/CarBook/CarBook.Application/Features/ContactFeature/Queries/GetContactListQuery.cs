using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.ContactFeature.DTOs;
using CarBook.Application.Repository.Services;
using MediatR;

namespace CarBook.Application.Features.ContactFeature.Queries;

public class GetContactListQuery:IRequest<IList<GetContactListDto>>
    {
        public class Handler(IContactRepository contactRepository, IMapper mapper) : IRequestHandler<GetContactListQuery, IList<GetContactListDto>>
        {
            public async Task<IList<GetContactListDto>> Handle(GetContactListQuery request, CancellationToken cancellationToken)
            {
                var contacts = await contactRepository.GetAllAsync();

                return contacts.Select(c => mapper.Map<GetContactListDto>(c)).ToList();
            }
        }
    }
