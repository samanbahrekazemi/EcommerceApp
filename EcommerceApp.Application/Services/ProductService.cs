using AutoMapper;
using AutoMapper.QueryableExtensions;
using EcommerceApp.Domain.Entities;
using EcommerceApp.Domain.Exceptions;
using EcommerceApp.Domain.Interfaces;
using EcommerceApp.Domain.ValueObjects;
using EcommerceApp.Shared.DTOs;
using EcommerceApp.Shared.Models;
using MediatR;
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
        private readonly ILogger<ProductService> _logger;
        public ProductService(IRepository<Product, ProductId> repository, IMapper mapper, ILogger<ProductService> logger, IProductRepository productRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _productRepository = productRepository;
        }

      
        public async Task<Result<ProductDto?>> FindAsync(int id)
        {
            try
            {
                var entity = await _repository.FindAsync(id);
                if (entity != null)
                    return Result<ProductDto?>.Success();
                throw new NotFoundEntityException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Result<ProductDto?>.Failure(ex.Message);
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

        public async Task<Result<ProductDto?>> UpdateAsync(ProductDto productDto)
        {
            try
            {
                var entity = await _repository.FindAsync(productDto.Id);
                if (entity == null) throw new NotFoundEntityException();
                await _repository.UpdateAsync(_mapper.Map<Product>(productDto));
                return Result<ProductDto?>.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Result<ProductDto?>.Failure(ex.Message);
            }
        }

        public async Task<Result<ProductDto?>> AddAsync(ProductDto productDto)
        {
            try
            {
                await _repository.AddAsync(_mapper.Map<Product>(productDto));
                return Result<ProductDto?>.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Result<ProductDto?>.Failure(ex.Message);
            }
        }

        public async Task<Result<ProductDto?>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _repository.FindAsync(id);
                if (entity == null) throw new NotFoundEntityException();
                await _repository.DeleteAsync(id);
                return Result<ProductDto?>.Success();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Result<ProductDto?>.Failure(ex.Message);
            }
        }
    }
}
