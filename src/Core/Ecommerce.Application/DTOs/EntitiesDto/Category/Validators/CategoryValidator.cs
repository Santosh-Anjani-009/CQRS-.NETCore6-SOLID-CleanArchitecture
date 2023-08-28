using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.EntitiesDto.Category.Validators
{
    public class CategoryValidator: AbstractValidator<CategoryDto>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MinimumLength(3).WithMessage("{PropertyName} limit with 3 characters")
                .MaximumLength(50).WithMessage("{PropertyName} maximum character limit is 50");
        }
    }
}
