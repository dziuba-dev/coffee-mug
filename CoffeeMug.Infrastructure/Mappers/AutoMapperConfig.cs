using AutoMapper;
using CoffeeMug.Core.Domain;
using CoffeeMug.Infrastructure.DTO;

namespace CoffeeMug.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>();
            }).CreateMapper();
    }
}
