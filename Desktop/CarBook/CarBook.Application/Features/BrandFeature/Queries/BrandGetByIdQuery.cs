using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.BrandFeature.DTOs;
using CarBook.Application.Repository.Services;
using MediatR;

namespace CarBook.Application.Features.BrandFeature.Queries
{
    public class BrandGetByIdQuery(int id):IRequest<GetByIdBrandDto>
    {
        public int Id { get; set; } = id;

        public class Handler(IBrandRepository brandRepository, IMapper mapper) : IRequestHandler<BrandGetByIdQuery, GetByIdBrandDto>
        {
            public async Task<GetByIdBrandDto> Handle(BrandGetByIdQuery request, CancellationToken cancellationToken)
            {
                var brand = await brandRepository.GetAsync(b=> b.Id == request.Id); 

                return mapper.Map<GetByIdBrandDto>(brand);
            }
        }

    }
}