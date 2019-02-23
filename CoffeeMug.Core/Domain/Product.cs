using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CoffeeMug.Core.Domain
{
    public class Product : Entity
    {
        public string Name { get; protected set; }

        public decimal? Price { get; protected set; }

        public DateTime CreatedAt { get; protected set; }

        public DateTime UpdatedAt { get; protected set; }

        Regex PriceRegex = new Regex(@"^\d+\.?\d*$");

        protected Product() { }

        public Product (Guid id, string name, decimal? price)
        {
            Id = id;
            Name = name;
            Price = price;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateProduct(Guid id, string name, decimal? price)
        {
            Id = id;
            Name = name;
            Price = price;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
