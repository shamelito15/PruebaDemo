using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("{Name} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("{Name} el nombre no puede exceder los 50 caracteres");

            RuleFor(p => p.Description).NotEmpty().WithMessage("{Description} no puede estar vacio");
        }
    }
}
