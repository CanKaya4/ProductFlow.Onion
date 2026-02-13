using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductFlow.OnionTest.Server.Application.Features.Commands.ProductCommands;
using ProductFlow.OnionTest.Server.Application.Features.Queries.ProductQueries;

namespace ProductFlow.OnionTest.Server.API.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetProductQuery query)
        {
            var products = await _mediator.Send(query);
            return Ok(products);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(Id));
            return Ok(product);
        }
        [HttpGet("{slug}")]
        public async Task<IActionResult> GetBySlug(string slug)
        {
            var product = await _mediator.Send(new GetProductBySlugQuery(slug));
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ürün başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ürün başarıyla güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _mediator.Send(new RemoveProductCommand(id));
            return Ok();
        }
    }
}
