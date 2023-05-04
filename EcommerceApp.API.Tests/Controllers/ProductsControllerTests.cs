using AutoFixture;
using AutoMapper;
using EcommerceApp.Api.Controllers;
using EcommerceApp.Application.Features.Product.Commands;
using EcommerceApp.Application.Features.Product.Queries;
using EcommerceApp.Shared.DTOs;
using EcommerceApp.Shared.Models;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using X.PagedList;
using Xunit;

namespace EcommerceApp.API.Tests.Controllers
{
    public class ProductsControllerTests
    {
        private readonly Fixture _fixture;
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ProductsController _controller;

        public ProductsControllerTests()
        {
            _fixture = new Fixture();
            _mediatorMock = new Mock<IMediator>();
            _mapperMock = new Mock<IMapper>();
            _controller = new ProductsController(_mediatorMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetAllProducts_ReturnsOkResult_WithList()
        {
            // Arrange
            var products = _fixture.CreateMany<ProductDto>().ToList();
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetAllProductsQuery>(), default)).ReturnsAsync(products);

            // Act
            var result = await _controller.GetAllProducts();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            result.As<OkObjectResult>().Value.Should().BeOfType<List<ProductDto>>();
            result.As<OkObjectResult>().Value.As<List<ProductDto>>().Should().BeEquivalentTo(products);
        }



        [Fact]
        public async Task SearchProducts_ReturnsOkResult_WithPagedList()
        {
            // Arrange
            var query = _fixture.Create<SearchProductsQuery>();
            var products = _fixture.CreateMany<ProductDto>().ToPagedList(query.PageNumber, query.PageSize);
            var mediatorMock = new Mock<IMediator>();
            mediatorMock
                .Setup(x => x.Send(It.IsAny<SearchProductsQuery>(), default))
                .ReturnsAsync(products);

            // Act
            var result = await _controller.SearchProducts(query);

            // Assert
            result.Should().BeOfType<ActionResult<IPagedList<ProductDto>>>();
            result.Result.Should().BeOfType<OkObjectResult>();
        }


        
    }
}
