using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Application.Features.CarFeatureFeature.Commands;
using CarBook.Application.Features.CarFeatureFeature.DTOs;
using CarBook.Application.Features.CarFeatureFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class CarFeaturesController(IMediator mediatR) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await mediatR.Send(new GetCarFeatureListQuery());
            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id){

            var result = await mediatR.Send(new CarFeatureGetByIdQuery(id));

            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddCarFeatureCommand command){
            var result = await mediatR.Send(command);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateCarFeatureCommand command){
            var result = await mediatR.Send(command);

            return Ok(result);
        }

        [HttpDelete("DeleteById/{id}")]
        public async Task<IActionResult> DeleteById(int id){
            var result = await mediatR.Send(new DeleteCarFeatureCommand(id));

            return Ok(result);
        }
    }
