using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CarFeature.DTOs;

    public class CarGetByIdDto
    {

    public int BrandId { get; set; }

    public int CategoryId { get; set; }

    public Category Category{ get; set; }
    public Brand Brand { get; set; }

    public string Model { get; set; }

    public string ImageUrl { get; set; }

    public int Km { get; set; }

    public string Transmission { get; set; }

    public byte Seat { get; set; }

    public byte Luggage { get; set; }

    public string Fuel { get; set; }
    public List<CarPayment> CarPayments { get; set; }
    }
