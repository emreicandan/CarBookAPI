using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CarBook.Application.Features.UserFeature.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CarBook.Application.Utilities.Security;

public class JWTTokenGenerator(IConfiguration configuration):ITokenHelper<TokenModel>
{
     public TokenModel CreateToken(GetCheckUserDto result){
             var tokenOptions = configuration.GetSection("TokenOptions").Get<JWTTokenDefaults>();
             var claims = new List<Claim>();
             if(!string.IsNullOrWhiteSpace(result.Role))
                 claims.Add(new Claim(ClaimTypes.Role, result.Role));

                 claims.Add(new Claim(ClaimTypes.NameIdentifier,result.Id.ToString()));

             if(!string.IsNullOrWhiteSpace(result.UserName))
                 claims.Add(new Claim("Username",result.UserName));

             var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey));

             var signingCredentials = new SigningCredentials(key , SecurityAlgorithms.HmacSha256);

             var expirationDate = DateTime.UtcNow.AddDays(tokenOptions.ExpirationMinute);

             JwtSecurityToken token = new JwtSecurityToken(issuer:tokenOptions.Issuer,audience:tokenOptions.Audience,claims:claims,
             notBefore:DateTime.UtcNow,expires:expirationDate,signingCredentials:signingCredentials);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

             return new TokenModel(tokenHandler.WriteToken(token),expirationDate);  
         } 
    
}
        