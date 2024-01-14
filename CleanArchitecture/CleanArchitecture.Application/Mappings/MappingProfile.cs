

using AutoMapper;
using CleanArchitecture.Application.Features.Products.Commands.CreateProduct;
using CleanArchitecture.Application.Features.Products.Queries.GetProductList;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Mappings
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductVm>();
            CreateMap<CreateProductCommand, Product>();
        }
    }
}
