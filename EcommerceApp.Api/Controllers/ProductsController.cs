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
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
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
        public async Task<IActionResult> CreateProduct(ProductDto productDto)
        {
            var command = new CreateProductCommand
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId,
            };
            var result = await _mediator.Send(command);
            return Ok(result);

        }

    }
}
