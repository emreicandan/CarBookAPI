using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BrandFeature.DTOs
{
    public class GetByIdBrandDto
    {
        public int Id { get; set; } 

        public string Name { get; set; }    
    }
}