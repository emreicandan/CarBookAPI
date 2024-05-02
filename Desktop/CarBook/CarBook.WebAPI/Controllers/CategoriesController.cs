using CarBook.Application.Features.CategoryFeature.Commands;
using CarBook.Application.Features.CategoryFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController(IMediator mediatR) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(){

            var result = await mediatR.Send(new GetCategoryListQuery());

            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id){

            var result = await mediatR.Send(new CategoryGetByIdQuery(id));

            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddCategoryCommand command){
            var result = await mediatR.Send(command);

            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateCategoryCommand command){
            var result = await mediatR.Send(command);

            return Ok(result);
        }

        [HttpDelete("DeleteById/{id}")]
        public async Task<ActionResult> DeleteById(int id){
            var result = await mediatR.Send(new DeleteCategoryCommand(id));

            return Ok(result);
        }
    }
}