using CoffeeMug.Infrastructure.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMug.Infrastructure.Validators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProduct>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.ProductId)
                .NotNull()
                .WithMessage("Product id is required.");
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Product name is required.");
            RuleFor(x => x.Price)
                .NotNull()
                .WithMessage("Product price is required.");
        }
    }
}
