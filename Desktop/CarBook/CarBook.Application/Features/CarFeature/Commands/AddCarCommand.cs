using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.CarFeature.DTOs;
using CarBook.Application.Features.CarFeature.Rules;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using FluentValidation;
using MediatR;

namespace CarBook.Application.Features.CarFeature.Commands;

    public class AddCarCommand:IRequest<AddedCarDto>
    {
    public int BrandId { get; set; }

    public string Model { get; set; }

    public string ImageUrl { get; set; }

    public int Km { get; set; }

    public string Transmission { get; set; }

    public byte Seat { get; set; }

    public byte Luggage { get; set; }

    public string Fuel { get; set; }

    [JsonIgnore]

    public IEnumerable<IValidator> Validators { get; set; } = [new AddCarValidation()];

    public class Handler(ICarRepository carRepository, IMapper mapper) : IRequestHandler<AddCarCommand, AddedCarDto>
    {
        public async Task<AddedCarDto> Handle(AddCarCommand request, CancellationToken cancellationToken)
        {
            var car = mapper.Map<Car>(request);

            var addedCar = await carRepository.AddAsync(car);

            return mapper.Map<AddedCarDto>(addedCar);
        }
    }
}

