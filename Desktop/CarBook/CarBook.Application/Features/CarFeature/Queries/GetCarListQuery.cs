using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.CarFeature.DTOs;
using CarBook.Application.Repository.Services;
using MediatR;

namespace CarBook.Application.Features.CarFeature.Queries;

    public class GetCarListQuery:IRequest<IList<GetCarListDto>>
    {
    public class Handler(ICarRepository carRepository, IMapper mapper) : IRequestHandler<GetCarListQuery, IList<GetCarListDto>>
    {
        public async Task<IList<GetCarListDto>> Handle(GetCarListQuery request, CancellationToken cancellationToken)
        {
            var cars = await carRepository.GetAllAsync();

            return  cars.Select(c=> mapper.Map<GetCarListDto>(c)).ToList();
        }
    }
}
