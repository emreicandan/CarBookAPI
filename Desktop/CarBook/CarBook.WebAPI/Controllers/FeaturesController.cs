using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Application.Features.FatureFeature.Commands;
using CarBook.Application.Features.FatureFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeaturesController(IMediator mediatR) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(){

            var result = await mediatR.Send(new GetFeatureListQuery());

            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id){

            var result =await mediatR.Send(new FeatureGetByIdQuery(id));

            return Ok(result);  
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddFeatureCommand command){

            var result =await mediatR.Send(command);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateFeatureCommand command){

            var result =await mediatR.Send(command);

            return Ok(result);
        }

        [HttpDelete("DeleteById/{id}")]
        public async Task<IActionResult> DeleteById(int id){

            var result = await mediatR.Send(new DeleteFeatureCommand(id));

            return Ok(result);
        }
    }
}