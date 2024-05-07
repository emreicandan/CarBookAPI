using AutoMapper;
using CarBook.Application.Features.CarPaymentFeature.DTOs;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CarPaymentFeature.Queries;

public class CarPaymentGetByIdQuery(int id):IRequest<CarPaymentGetByIdDto>
{
    public int Id { get; set; } = id;

    public class Handler(ICarPaymentRepository carPaymentRepository, IMapper mapper) : IRequestHandler<CarPaymentGetByIdQuery, CarPaymentGetByIdDto>
    {
        public async Task<CarPaymentGetByIdDto> Handle(CarPaymentGetByIdQuery request, CancellationToken cancellationToken)
        {
            var carPayment = mapper.Map<CarPayment>(await carPaymentRepository.GetAsync(cp => cp.Id == request.Id));

            return mapper.Map<CarPaymentGetByIdDto>(carPayment);
        }
    }
}