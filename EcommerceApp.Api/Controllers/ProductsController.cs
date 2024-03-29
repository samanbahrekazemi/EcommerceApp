﻿using AutoMapper;
using EcommerceApp.Application.Features.Product.Commands;
using EcommerceApp.Application.Features.Product.Queries;
using EcommerceApp.Shared.DTOs;
using EcommerceApp.Shared.Models;
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

        [HttpGet("Search")]
        public async Task<ActionResult<IPagedList<ProductDto>>> SearchProducts([FromQuery] SearchProductsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        private IActionResult Result(Result<ProductDto?> result)
        {
            if (result != null)
            {
                if (result.Succeeded)
                    return Ok(result);
                else
                    return Problem(result.Message);
            }

            return Problem();
        }


        [HttpPost("Create")]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductCommand request)
        {
            var result = await _mediator.Send(request);
            return Result(result);
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
            return Result(result);
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var command = new DeleteProductCommand(id);
            var result = await _mediator.Send(command);
            return Result(result);
        }

    }
}
