using AutoMapper;
using CarBook.Application.Features.ContactFeature.DTOs;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.ContactFeature.Queries;

public class ContactGetByIdQuery(int id):IRequest<ContactGetByIdDto>
    {
        public int Id { get; set; } = id;

    public class Handler(IContactRepository contactRepository, IMapper mapper) : IRequestHandler<ContactGetByIdQuery, ContactGetByIdDto>
    {
        public async Task<ContactGetByIdDto> Handle(ContactGetByIdQuery request, CancellationToken cancellationToken)
        {
            var contact = mapper.Map<Contact>(await contactRepository.GetAsync(c=>c.Id == request.Id));

            return mapper.Map<ContactGetByIdDto>(contact);
        }
    }
}