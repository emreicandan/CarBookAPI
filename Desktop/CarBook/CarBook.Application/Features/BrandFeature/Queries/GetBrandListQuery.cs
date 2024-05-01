using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.BrandFeature.DTOs;
using CarBook.Application.Repository.Services;
using MediatR;

namespace CarBook.Application.Features.BrandFeature.Queries;

    public class GetBrandListQuery:IRequest<IList<BrandListDto>>
    {
    public class Handler(IBrandRepository brandRepository, IMapper mapper) : IRequestHandler<GetBrandListQuery, IList<BrandListDto>>
    {
        public async Task<IList<BrandListDto>   > Handle(GetBrandListQuery request, CancellationToken cancellationToken)
        {
            var brands = await brandRepository.GetAllAsync();

            return brands.Select(b => mapper.Map<BrandListDto>(b)).ToList();
        }
    }
}
