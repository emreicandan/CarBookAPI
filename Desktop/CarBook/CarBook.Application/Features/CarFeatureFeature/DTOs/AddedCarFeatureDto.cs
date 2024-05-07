using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CarFeatureFeature.DTOs;

public class AddedCarFeatureDto
    {
    public int CarId { get; set; }

    public int FeatureId { get; set; }

    public Car Car { get; set; }

    public Feature Features { get; set; }

    public bool Available { get; set; }
    }
