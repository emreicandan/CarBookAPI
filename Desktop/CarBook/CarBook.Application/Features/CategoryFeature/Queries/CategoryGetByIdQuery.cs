using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.CategoryFeature.DTOs;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CategoryFeature.Queries;

    public class CategoryGetByIdQuery(int id):IRequest<CategoryGetByIdDto>
    {
        public int Id { get; set; } = id;
    public class Handler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<CategoryGetByIdQuery, CategoryGetByIdDto>
    {
        public async Task<CategoryGetByIdDto> Handle(CategoryGetByIdQuery request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<Category>(await categoryRepository.GetAsync(c=>c.Id==request.Id));

            return mapper.Map<CategoryGetByIdDto>(category);
        }
    }
}
