using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities;
public class Category:Entity<int>
{
    public int CarId { get; set; }

    public string Name { get; set; }

    public Car Car { get; set; }
}