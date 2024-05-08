using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBook.Application.Utilities.Security;

    public class TokenModel(string token , DateTime expirationDate)
    {
        public string Token { get; set; } = token;

        public DateTime ExpirationDate { get; set; } = expirationDate;
    }
