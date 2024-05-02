using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Application.Features.PaymentFeature.Commands;
using CarBook.Application.Features.PaymentFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController(IMediator mediatR) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(){

            var result = await mediatR.Send(new GetPaymentListQuery());

            return Ok(result);  
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id){

            var result = await mediatR.Send(new PaymentGetByIdQuery(id));
            return Ok(result);  
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]AddPaymentCommand command){
            var result = await mediatR.Send(command);

            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]UpdatePaymentCommand command){
            var result = await mediatR.Send(command);

            return Ok(result);
        }

        [HttpDelete("DeleteById/{id}")]
        public async Task<IActionResult> DeleteById(int id){
            var result = await mediatR.Send(new DeletePaymentCommand(id));

            return Ok(result);
        }
    }
}