using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.CategoryFeature.DTOs;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CategoryFeature.Commands;

    public class AddCategoryCommand:IRequest<AddedCategoryDto>
    {
    public string Name { get; set;}
    public class Handler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<AddCategoryCommand, AddedCategoryDto>
    {
        public async Task<AddedCategoryDto> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<Category>(request);
            var addedCategory = await categoryRepository.AddAsync(category);

            return mapper.Map<AddedCategoryDto>(addedCategory);
        }
    }
}
