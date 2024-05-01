using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBook.Domain;

    public class Entity
    {
        
    }

    public class Entity<T> : Entity{

        public T Id { get; set; }
    }
