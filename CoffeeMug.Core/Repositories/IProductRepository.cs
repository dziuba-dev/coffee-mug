using CoffeeMug.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeMug.Core.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAsync();
        Task<Product> GetAsync(Guid id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
    }
}
