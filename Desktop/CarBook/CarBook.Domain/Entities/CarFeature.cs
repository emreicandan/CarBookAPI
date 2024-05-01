using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities;
public class CarFeature:Entity<int>
{
    public int CarId { get; set; }

    public int FeatureId { get; set; }

    public Car Car { get; set; }

    public Feature Features { get; set; }

    public bool Available { get; set; }
}