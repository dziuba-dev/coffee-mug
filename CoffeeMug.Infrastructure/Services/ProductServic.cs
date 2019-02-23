using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CoffeeMug.Core.Domain;
using CoffeeMug.Core.Repositories;
using CoffeeMug.Infrastructure.DTO;
using CoffeeMug.Infrastructure.Extensions;

namespace CoffeeMug.Infrastructure.Services
{
    public class ProductServic : IProductServic
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductServic(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAsync()
        {
            var result = await _productRepository.GetAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetAsync(Guid id)
        {
            var result = await _productRepository.GetAsync(id);

            return _mapper.Map<ProductDTO>(result);
        }

        public async Task CreateAsync(Guid id, string name, decimal? price)
        {
            var product = await _productRepository.GetForCreateOrFileAsync(id, name);
            product = new Product(id, name, price);

            await _productRepository.AddAsync(product);
        }

        public async Task UpdateAsync(Guid id, string name, decimal? price)
        {
            var product = await _productRepository.GetForUpdateOrFileAsync(id);
            product.UpdateProduct(id, name, price);

            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _productRepository.GetForUpdateOrFileAsync(id);

            await _productRepository.DeleteAsync(product);
        }
    }
}
