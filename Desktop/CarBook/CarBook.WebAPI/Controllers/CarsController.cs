using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Application.Features.CarFeature.Commands;
using CarBook.Application.Features.CarFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController(IMediator mediatR) : ControllerBase
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddCarCommand command){

            var result = await mediatR.Send(command);

            return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(){

            var result = await mediatR.Send(new GetCarListQuery());

            return Ok(result);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id){

            var result = await mediatR.Send(new CarGetByIdQuery(id));

            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateCarCommand command){

            var result = mediatR.Send(command);

            return Ok(result);
        }

        [HttpDelete("DeleteById/{id}")]
        public async Task<IActionResult> DeleteById(int id) {

            var result = await mediatR.Send(new DeleteCarCommand(id));

            return Ok(result);
        }
    }
}