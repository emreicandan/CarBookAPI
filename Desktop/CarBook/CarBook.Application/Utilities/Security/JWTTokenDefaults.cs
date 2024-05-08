using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CarBook.Application.Utilities.Security;

    public class JWTTokenDefaults
    {
        public string Issuer { get; set; }  

        public string Audience { get; set; }    

        public string SecurityKey { get; set; }

        public int ExpirationMinute { get; set; }

    // public const string Issuer = "https://localhost";
    // public const string Audience = "https://localhost";
    // public const string SecurityKey = "33c3e590790710842ac785ceba6bdf66f54b154f5c8a2d50b710a12f994630e3";
    // public const int ExpirationMinute = 15;
    }
