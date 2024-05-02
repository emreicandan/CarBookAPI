using AutoMapper;
using CarBook.Application.Features.PaymentFeature.DTOs;
using CarBook.Application.Repository.Services;
using CarBook.Application.Utilities;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.PaymentFeature.Commands;

public class UpdatePaymentCommand:IRequest<UpdatedPaymentDto>
    {
        public int Id { get; set; }
        public string PlanName { get; set; }

    public class Handler(IPaymentRepository paymentRepository, IMapper mapper) : IRequestHandler<UpdatePaymentCommand, UpdatedPaymentDto>
    {
        public async Task<UpdatedPaymentDto> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = mapper.Map<Payment>(await paymentRepository.GetAsync(p=> p.Id == request.Id)).MapWithSource(request);

            var updatedPayment = await paymentRepository.UpdateAsync(payment);

            return mapper.Map<UpdatedPaymentDto>(updatedPayment);
        }
    }
}
