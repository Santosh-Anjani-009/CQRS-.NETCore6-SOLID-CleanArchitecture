using Ecommerce.Application.Persistance.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.EntitiesDto.Product.Validators
{
    public class ProductValidator: AbstractValidator<ProductDto>
    {
        public ProductValidator(IProductRepository repository) 
        {
            RuleFor(x => x.Name)
                  .NotNull()
                  .NotEmpty().WithMessage("{PropertyName} is required")
                  .MinimumLength(3).WithMessage("{PropertyName} limit with {ComparisonValue} characters")
                  .MaximumLength(50).WithMessage("{PropertyName} maximum character limit is {ComparisonValue}");
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}")
                .MustAsync(async (id, token) =>
                {
                    var categoryIdExists = await repository.Exists(id);
                    return !categoryIdExists;
                }).WithMessage("{PropertyName} doesn't exists ?");
        }
    }
}
