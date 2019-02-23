using System;

namespace CoffeeMug.Infrastructure.Commands
{
    public class UpdateProduct
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }
}
