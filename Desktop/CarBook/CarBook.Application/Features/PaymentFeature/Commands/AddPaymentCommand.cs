using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.PaymentFeature.DTOs;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.PaymentFeature.Commands;

public class AddPaymentCommand:IRequest<AddedPaymentDto>
    {
        public string PlanName { get; set; }

    public class Handler(IPaymentRepository paymentRepository, IMapper mapper) : IRequestHandler<AddPaymentCommand, AddedPaymentDto>
    {
        public async Task<AddedPaymentDto> Handle(AddPaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = mapper.Map<Payment>(request);

            var addedPayment = await paymentRepository.AddAsync(payment);

            return mapper.Map<AddedPaymentDto>(addedPayment);
        }
    }
}
