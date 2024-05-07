using AutoMapper;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CarPaymentFeature.Commands;

public class DeleteCarPaymentCommand(int id) : IRequest<bool>
{
    public int Id {get; set; } = id;

    public class Handler(ICarPaymentRepository carPaymentRepository, IMapper mapper) : IRequestHandler<DeleteCarPaymentCommand, bool>
    {
        public async Task<bool> Handle(DeleteCarPaymentCommand request, CancellationToken cancellationToken)
        {
            var carPayment = mapper.Map<CarPayment>(await carPaymentRepository.GetAsync(cp=> cp.Id == request.Id));

            await carPaymentRepository.DeleteAsync(carPayment);

            return true;
        }
    }

}