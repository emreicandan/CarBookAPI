using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Application.Features.BrandFeature.Commands;
using CarBook.Application.Features.BrandFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarBook.WebAPI.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController(IMediator mediatR) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(){

            var result = await mediatR.Send(new GetBrandListQuery());

            return Ok(result);  
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id){

            var result = await mediatR.Send(new BrandGetByIdQuery(id));
            return Ok(result);  
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]AddBrandCommand command){
            var result = await mediatR.Send(command);

            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]UpdateBrandCommand command){
            var result = await mediatR.Send(command);

            return Ok(result);
        }

        [HttpDelete("DeleteById/{id}")]
        public async Task<IActionResult> DeleteById(int id){
            var result = await mediatR.Send(new DeleteBrandCommand(id));

            return Ok(result);
        }
    }
