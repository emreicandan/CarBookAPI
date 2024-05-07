using AutoMapper;
using CarBook.Application.Features.CarPaymentFeature.DTOs;
using CarBook.Application.Repository.Services;
using CarBook.Application.Utilities;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CarPaymentFeature.Commands;

public class UpdateCarPaymentCommand:IRequest<UpdatedCarPaymentDto>
{
    public int Id { get; set; }
    public int CarId { get; set; }

    public int PaymentId { get; set; }

    public decimal Price { get; set; }

    public class Handler(ICarPaymentRepository carPaymentRepository, IMapper mapper) : IRequestHandler<UpdateCarPaymentCommand, UpdatedCarPaymentDto>
    {
        public async Task<UpdatedCarPaymentDto> Handle(UpdateCarPaymentCommand request, CancellationToken cancellationToken)
        {
            var carPayment = mapper.Map<CarPayment>(await carPaymentRepository.GetAsync(cp=>cp.Id == request.Id)).MapWithSource(request);

            var updatedCarPayment = await carPaymentRepository.UpdateAsync(carPayment);

            return mapper.Map<UpdatedCarPaymentDto>(updatedCarPayment);
        }
    }
}
