using FluentValidation;

namespace CleanArchitecture.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("{Name} no permite valores nulos");

            RuleFor(p => p.Description).NotNull().WithMessage("{Description} no permite valores nulos");
        }
    }
}
