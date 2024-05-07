using AutoMapper;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.ContactFeature.Commands;

public class DeleteContactCommand(int id) : IRequest<bool>
{
    public int Id { get; set; }=id;

    public class Handler(IContactRepository contactRepository, IMapper mapper) : IRequestHandler<DeleteContactCommand, bool>
    {
        public async Task<bool> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = mapper.Map<Contact>(await contactRepository.GetAsync(c=>c.Id == request.Id));

            await contactRepository.DeleteAsync(contact);

            return  true;
        }
    }

}