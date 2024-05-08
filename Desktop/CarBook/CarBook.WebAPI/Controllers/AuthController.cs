using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Application.Features.UserFeature.Commands;
using CarBook.Application.Features.UserFeature.Queries;
using CarBook.Application.Utilities.Security;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IMediator mediator,IConfiguration configuration) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register(AddUserCommand command){
        
        var result = await mediator.Send(command);

        return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(GetCheckUserQuery query){

            var values = await mediator.Send(query);

            if(values.IsExist)
            {
                return Created("",new JWTTokenGenerator(configuration).CreateToken(values));
            }
            else{
                return BadRequest("Username or password is incorrect");
            }
        }
    }
}