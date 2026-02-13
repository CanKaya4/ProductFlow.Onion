using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductFlow.OnionTest.Server.Application.Features.Commands.CategoryCommands;
using ProductFlow.OnionTest.Server.Application.Features.Queries.CategoryQueries;
using ProductFlow.OnionTest.Server.Application.Features.Results.CategoryResults;

namespace ProductFlow.OnionTest.Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _mediator.Send(new GetCategoryQuery());
            return Ok(categories);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var category = await _mediator.Send(new GetCategoryByIdQuery(Id));
            return Ok(category);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryCommand command)
        {
           await _mediator.Send(command);
            return Ok();
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            await _mediator.Send(new RemoveCategoryCommand(Id));
            return Ok();
        }
    }
}
