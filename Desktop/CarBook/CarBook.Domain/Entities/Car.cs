using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities;

public class Car:Entity<int>
{
    public int BrandId { get; set; }

    public Brand Brand { get; set; }

    public string Model { get; set; }

    public string ImageUrl { get; set; }

    public int Km { get; set; }

    public string Transmission { get; set; }

    public byte Seat { get; set; }

    public byte Luggage { get; set; }

    public string Fuel { get; set; }

    public List<CarFeature> CarFeatures { get; set; }

    public List<CarPayment> CarPayments { get; set; }
}