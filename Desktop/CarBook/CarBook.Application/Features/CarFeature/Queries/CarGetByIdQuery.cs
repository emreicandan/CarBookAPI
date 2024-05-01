using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.CarFeature.DTOs;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CarFeature.Queries
{
    public class CarGetByIdQuery(int id):IRequest<CarGetByIdDto>
    {
        public int Id { get; set; }

        public class Handler(ICarRepository carRepository, IMapper mapper) : IRequestHandler<CarGetByIdQuery, CarGetByIdDto>
        {
            public async Task<CarGetByIdDto> Handle(CarGetByIdQuery request, CancellationToken cancellationToken)
            {
                var car = mapper.Map<Car>(await carRepository.GetAsync(c => c.Id == request.Id));

                return mapper.Map<CarGetByIdDto>(car);    
            }
        }

    }
}