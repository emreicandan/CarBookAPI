using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.ContactFeature.DTOs;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.ContactFeature.Commands;


public class AddContactCommand : IRequest<AddedContactDto>
    {
    public string Name { get; set; }

    public string Email { get; set; }

    public string Subject { get; set; }

    public string Message { get; set; }

    public DateTime CreatedDate { get; set; }

    public class Handler(IContactRepository contactRepository, IMapper mapper) : IRequestHandler<AddContactCommand, AddedContactDto>
    {
        public async Task<AddedContactDto> Handle(AddContactCommand request, CancellationToken cancellationToken)
        {
            var contact = mapper.Map<Contact>(request);

            var addedContact = await contactRepository.AddAsync(contact);

            return mapper.Map<AddedContactDto>(addedContact);
        }
    }
}
