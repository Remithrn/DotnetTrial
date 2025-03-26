using Product_Entities.Products.Models;
using Product_Entities.Products.Payload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Entities.Products.Mapper
{
    public class ProductMapper
    {
        public static ProductEntity ToEntity(ProductPayload payload, long? productId = null)
        {
            return new ProductEntity
            {
                ProductId = productId,
                Name = payload.Name,
                Description = payload.Description,
                Price = payload.Price,
                StockQuantity = payload.StockQuantity,

            };
        }
        public static ProductDto ToDto(ProductEntity entity)
        {
            return new ProductDto
            {
                ProductId = entity.ProductId ?? 0,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                StockQuantity = entity.StockQuantity,
                CreatedAt = entity.CreatedAte
            };
        }
    }
}
