using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CarFeature.Commands
{
    public class DeleteCarCommand(int id):IRequest<bool>
    {
        public int Id {get; set;} = id;

        public class Handler(ICarRepository carRepository, IMapper mapper) : IRequestHandler<DeleteCarCommand, bool>
        {
            public async Task<bool> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
            {
                var car = mapper.Map<Car>(request);

                await carRepository.DeleteAsync(car);

                return true;
            }
        }
    }
}