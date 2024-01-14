using MediatR;

namespace CleanArchitecture.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? StatusName { get; set; } = string.Empty;
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalPrice { get; set; }
    }
}
