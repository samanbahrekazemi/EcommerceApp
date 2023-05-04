using EcommerceApp.Domain.Events.Product;
using EcommerceApp.Domain.Interfaces;
using EcommerceApp.Shared.DTOs;
using EcommerceApp.Shared.Models;
using MediatR;

namespace EcommerceApp.Application.Features.Product.Commands
{
    public class DeleteProductCommand : IRequest<Result<ProductDto?>>
    {
        public DeleteProductCommand()
        {

        }
        public DeleteProductCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }


    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result<ProductDto?>>
    {
        private readonly IProductService _productService;
        private readonly IEventHandler _eventHandler;

        public DeleteProductCommandHandler(IProductService productService, IEventHandler eventHandler)
        {
            _productService = productService;
            _eventHandler = eventHandler;
        }

        public async Task<Result<ProductDto?>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            // Delete
            var result = await _productService.DeleteAsync(request.Id);

            // Raise @Event
            await _eventHandler.PublishAsync(new ProductDeletedEvent() { ProductDto = result.Data, Description = result.Message });
            return result;
        }
    }

}
