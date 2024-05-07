using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.CarPaymentFeature.DTOs;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CarPaymentFeature.Commands;

public class AddCarPaymentCommand:IRequest<AddedCarPaymentDto>
    {
    public int CarId { get; set; }

    public int PaymentId { get; set; }

    public decimal Price { get; set; }

    public class Handler(ICarPaymentRepository carPaymentRepository, IMapper mapper) : IRequestHandler<AddCarPaymentCommand, AddedCarPaymentDto>
    {
        public async Task<AddedCarPaymentDto> Handle(AddCarPaymentCommand request, CancellationToken cancellationToken)
        {
            var carPayment = mapper.Map<CarPayment>(request);

            var addedCarPayment = await carPaymentRepository.AddAsync(carPayment);

            return mapper.Map<AddedCarPaymentDto>(addedCarPayment);
        }
    }
}
