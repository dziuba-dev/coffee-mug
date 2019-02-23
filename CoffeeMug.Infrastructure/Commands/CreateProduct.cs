using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeMug.Infrastructure.Commands
{
    public class CreateProduct
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }
}
