using AutoMapper;
using EcommerceApp.Application.Features.Product.Commands;
using EcommerceApp.Application.Features.Product.Queries;
using EcommerceApp.Shared.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace EcommerceApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ProductsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpPost("")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IPagedList<ProductDto>>> SearchProducts([FromQuery] SearchProductsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [HttpPost("Create")]
        public async Task<IActionResult> CreateProduct([FromForm] ProductDto productDto)
        {
            var command = new CreateProductCommand
            {
                ProductDto = productDto
            };
            var result = await _mediator.Send(command);
            return Ok(result);

        }


        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> EditProduct(int id, [FromForm] ProductDto productDto)
        {
            var command = new UpdateProductCommand
            {
                Id = id,
                ProductDto = productDto
            };
            var result = await _mediator.Send(command);
            if (result.Succeeded)
                return Ok(result);
            else
                return Problem(result.Message);

        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var command = new DeleteProductCommand { Id = id };
            var result = await _mediator.Send(command);
            if (result.Succeeded)
                return NoContent();
            else
                return Problem(result.Message);
        }

    }
}
