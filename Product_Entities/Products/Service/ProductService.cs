using Product_Entities.Products.Interface;
using Product_Entities.Products.Mapper;
using Product_Entities.Products.Payload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Entities.Products.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductDto?> GetByIdAsync(long productId)
        {
            var entity = await _repository.GetByIdAsync(productId);
            return entity != null ? ProductMapper.ToDto(entity) : null;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(ProductMapper.ToDto);
        }

        public async Task<ProductDto> CreateAsync(ProductPayload payload)
        {
            var entity = ProductMapper.ToEntity(payload);
            await _repository.AddAsync(entity);
            return ProductMapper.ToDto(entity);
        }

        public async Task<ProductDto?> UpdateAsync(long productId, ProductPayload payload)
        {
            var existingProduct = await _repository.GetByIdAsync(productId);
            if (existingProduct == null) return null;

            existingProduct.Name = payload.Name;
            existingProduct.Description = payload.Description;
            existingProduct.Price = payload.Price;
            existingProduct.StockQuantity = payload.StockQuantity;

            await _repository.UpdateAsync(existingProduct);
            return ProductMapper.ToDto(existingProduct);
        }

        public async Task<bool> DeleteAsync(long productId)
        {
            var existingProduct = await _repository.GetByIdAsync(productId);
            if (existingProduct == null) return false;

            await _repository.DeleteAsync(productId);
            return true;
        }
    }
}
