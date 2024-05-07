using AutoMapper;
using CarBook.Application.Features.ContactFeature.DTOs;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.ContactFeature.Commands;

public class UpdateContactCommand : IRequest<UpdatedContactDto>
 {
    public int Id { get; set; }
    public string Name { get; set; }

    public string Email { get; set; }

    public string Subject { get; set; }

    public string Message { get; set; }

    public DateTime CreatedDate { get; set; }

    public class Handler(IContactRepository contactRepository, IMapper mapper) : IRequestHandler<UpdateContactCommand, UpdatedContactDto>
    {
        public async Task<UpdatedContactDto> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = mapper.Map<Contact>(await contactRepository.GetAsync(c=>c.Id==request.Id));

            var updatedContact = await contactRepository.UpdateAsync(contact);

            return mapper.Map<UpdatedContactDto>(updatedContact);
        }
    }
}
