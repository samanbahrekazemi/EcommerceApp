using AutoMapper;
using EcommerceApp.Domain.Interfaces;
using EcommerceApp.Shared.DTOs;
using EcommerceApp.Shared.Models;
using MediatR;

namespace EcommerceApp.Application.Features.Product.Commands
{
    public class DeleteProductCommand : IRequest<Result<ProductDto?>>
    {
        public int Id { get; set; }
    }


    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result<ProductDto?>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<Result<ProductDto?>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await _productService.DeleteAsync(request.Id);
        }
    }

}
