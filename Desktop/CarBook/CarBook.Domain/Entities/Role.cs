using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities;

    public class Role:Entity<int>
    {
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
