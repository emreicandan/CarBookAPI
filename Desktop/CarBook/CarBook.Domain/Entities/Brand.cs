using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities;

    public class Brand:Entity<int>
    {
        public string Name { get; set; }
    }
