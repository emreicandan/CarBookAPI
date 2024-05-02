using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using CarBook.Application.Features.PaymentFeature.DTOs;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.PaymentFeature.Queries;

public class PaymentGetByIdQuery(int id):IRequest<PaymentGetByIdDto>
    {
        public int Id { get; set; } = id;

    public class Handler(IPaymentRepository paymentRepository, IMapper mapper) : IRequestHandler<PaymentGetByIdQuery, PaymentGetByIdDto>
    {
        public async Task<PaymentGetByIdDto> Handle(PaymentGetByIdQuery request, CancellationToken cancellationToken)
        {
            var payment = mapper.Map<Payment>(await paymentRepository.GetAsync(p=> p.Id == request.Id));

            return mapper.Map<PaymentGetByIdDto>(payment);
        }
    }
}