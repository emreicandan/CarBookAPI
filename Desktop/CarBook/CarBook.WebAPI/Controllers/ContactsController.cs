using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Application.Features.ContactFeature.Commands;
using CarBook.Application.Features.ContactFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController(IMediator mediatR) : ControllerBase
    {
        [HttpGet("GetAll")]

        public async Task<IActionResult> GetAll()
        {
            var result = await mediatR.Send(new GetContactListQuery());

            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await mediatR.Send(new ContactGetByIdQuery(id));

            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddContactCommand command)
        {
            var result = await mediatR.Send(command);

            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateContactCommand command)
        {
            var result = await mediatR.Send(command);

            return Ok(result);
        }

        [HttpDelete("DeleteById/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await mediatR.Send(new DeleteContactCommand(id));    

            return Ok(result);
        }
    }
