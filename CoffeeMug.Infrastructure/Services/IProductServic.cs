using CoffeeMug.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeMug.Infrastructure.Services
{
    public interface IProductServic
    {
        Task<IEnumerable<ProductDTO>> GetAsync();
        Task<ProductDTO> GetAsync(Guid id);
        Task CreateAsync(Guid id, string name, decimal? price);
        Task UpdateAsync(Guid id, string name, decimal? price);
        Task DeleteAsync(Guid id);
    }
}
