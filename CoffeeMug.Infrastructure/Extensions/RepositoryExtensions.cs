using CoffeeMug.Core.Domain;
using CoffeeMug.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace CoffeeMug.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<Product> GetForCreateOrFileAsync(this IProductRepository productRepository, Guid id, string name)
        {
            var product = await productRepository.GetAsync(id);
            if (product != null)
            {
                throw new Exception($"Product named: '{name}' already exist.");
            }
            return product;
        }

        public static async Task<Product> GetForUpdateOrFileAsync(this IProductRepository productRepository, Guid id)
        {
            var product = await productRepository.GetAsync(id);
            if (product == null)
            {
                throw new Exception($"Product with id: '{id}' does not exist.");
            }
            return product;
        }
    }
}
