using Product_Entities.Products.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product_Entities.Products.Interface
{
    public interface IProductRepository
    {
        Task<ProductEntity?> GetByIdAsync(long productId);
        Task<IEnumerable<ProductEntity>> GetAllAsync();
        Task AddAsync(ProductEntity product);
        Task UpdateAsync(ProductEntity product);
        Task DeleteAsync(long productId);
    }
}

