using Product_Entities.Products.Payload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Entities.Products.Interface
{
    public interface IProductService
    {
        Task<ProductDto?> GetByIdAsync(long productId);
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> CreateAsync(ProductPayload payload);
        Task<ProductDto?> UpdateAsync(long productId, ProductPayload payload);
        Task<bool> DeleteAsync(long productId);
    }
}
