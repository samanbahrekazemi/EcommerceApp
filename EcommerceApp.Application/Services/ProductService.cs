using AutoMapper;
using AutoMapper.QueryableExtensions;
using EcommerceApp.Domain.Entities;
using EcommerceApp.Domain.Interfaces;
using EcommerceApp.Domain.ValueObjects;
using EcommerceApp.Shared.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using X.PagedList;

namespace EcommerceApp.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product, ProductId> _repository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        ILogger<ProductService> _logger;
        public ProductService(IRepository<Product, ProductId> repository, IMapper mapper, ILogger<ProductService> logger, IProductRepository productRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _productRepository = productRepository;
        }

        public async Task<bool> AddAsync(ProductDto productDto)
        {
            try
            {
                await _repository.AddAsync(_mapper.Map<Product>(productDto));
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return true;
            }
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<List<ProductDto>>(list);
        }

        public async Task<IPagedList<ProductDto>> SearchProductsAsync(int pageNumber, int pageSize, string searchQuery, string sortBy)
        {
            var productsQuery = _productRepository.Querable();


            // Apply search filter
            if (!string.IsNullOrEmpty(searchQuery))
            {
                productsQuery = productsQuery.Where(p =>
                    p.Name.Contains(searchQuery) ||
                    (p.Description != null && p.Description.Contains(searchQuery)) ||
                    p.ProductTags.Any(t => t.Tag.Name.Contains(searchQuery))
                );
            }

            // Apply sorting
            switch (sortBy)
            {
                case "date_desc":
                    productsQuery = productsQuery.OrderByDescending(p => p.CreatedAt);
                    break;
                case "date":
                    productsQuery = productsQuery.OrderBy(p => p.CreatedAt);
                    break;
                case "price":
                    productsQuery = productsQuery.OrderBy(p => p.Price);
                    break;
                default:
                    productsQuery = productsQuery.OrderBy(p => p.Name);
                    break;
            }
            var totalItems = await productsQuery.AsNoTracking().CountAsync();
            return await productsQuery.ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .ToPagedListAsync(pageNumber, pageSize, totalItems);

        }
    }
}
