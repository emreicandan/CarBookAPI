using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CategoryFeature.DTOs;

    public class CategoryGetByIdDto
    {
        public int Id {get;set;}

        public string Name {get;set;}

    }
