using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.CarFeature.DTOs;
using CarBook.Application.Features.CarFeature.Rules;
using CarBook.Application.Pipelines.Validation;
using CarBook.Application.Repository.Services;
using CarBook.Application.Utilities;
using CarBook.Domain.Entities;
using FluentValidation;
using MediatR;

namespace CarBook.Application.Features.CarFeature.Commands;

    public class UpdateCarCommand:IRequest<UpdatedCarDto> , IRequestValidator
    {
    public int Id { get; set; }
    public int BrandId { get; set; }

    public int CategoryId { get; set; }
    public string Model { get; set; }

    public string ImageUrl { get; set; }

    public int Km { get; set; }

    public string Transmission { get; set; }

    public byte Seat { get; set; }

    public byte Luggage { get; set; }

    public string Fuel { get; set; }

        [JsonIgnore]
        public IEnumerable<IValidator> Validators{ get; set; } = [new UpdateCarValidator()];
        public class Handler(ICarRepository carRepository, IMapper mapper) : IRequestHandler<UpdateCarCommand, UpdatedCarDto>
        {
            public async Task<UpdatedCarDto> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
            {
                var car = mapper.Map<Car>( await carRepository.GetAsync(b=> b.Id == request.Id)).MapWithSource(request);
                var updatedCar = await carRepository.UpdateAsync(car);

                return mapper.Map<UpdatedCarDto>(updatedCar);
            }
        }
    }