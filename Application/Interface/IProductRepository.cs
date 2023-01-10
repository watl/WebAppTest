using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IProductRepository : IGenericRepository<Product> 
    {
       
        Task<Product> GetByNameAsync(string name);
        Task<IReadOnlyList<ProductDTO>> GetBySkuAsync(string name);
        Task<IReadOnlyList<ProductDTO>> GetActiveProductsAsync();
        Task<IReadOnlyList<ProductDTO>> GetByDescriptionAsync(string name);
        Task<int> AddProductAsync(Product prod);

    }
}
