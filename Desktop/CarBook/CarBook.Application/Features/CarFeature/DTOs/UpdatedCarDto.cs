using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarFeature.DTOs
{
    public class UpdatedCarDto
    {
    public int Id { get; set; }
    public int BrandId { get; set; }
    public string Model { get; set; }

    public string ImageUrl { get; set; }

    public int Km { get; set; }

    public string Transmission { get; set; }

    public byte Seat { get; set; }

    public byte Luggage { get; set; }

    public string Fuel { get; set; }
    }
}