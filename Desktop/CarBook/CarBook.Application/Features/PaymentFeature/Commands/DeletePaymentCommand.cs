using AutoMapper;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.PaymentFeature.Commands;

public class DeletePaymentCommand(int id):IRequest<bool>
    {
        public int Id { get; set; } = id;

    public class Handler(IPaymentRepository paymentRepository, IMapper mapper) : IRequestHandler<DeletePaymentCommand, bool>
    {
        public async Task<bool> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = mapper.Map<Payment>( await paymentRepository.GetAsync(p=>p.Id == request.Id));

            await paymentRepository.DeleteAsync(payment);

            return true;
        }
    }
}