using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.CategoryFeature.DTOs;
using CarBook.Application.Repository.Services;
using MediatR;

namespace CarBook.Application.Features.CategoryFeature.Queries;

    public class GetCategoryListQuery:IRequest<IList<GetCategoryListDto>>
    {
    public class Handler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<GetCategoryListQuery, IList<GetCategoryListDto>>
    {
        public async Task<IList<GetCategoryListDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categoryList = await categoryRepository.GetAllAsync();

            return categoryList.Select(c => mapper.Map<GetCategoryListDto>(c)).ToList();
        }
    }
}
