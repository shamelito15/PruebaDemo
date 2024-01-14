

using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Products.Queries.GetProductList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductVm>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductListQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductVm>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var productList = await _productRepository.GetProductoByNombre(request._Username);
            return _mapper.Map<List<ProductVm>>(productList);
        }
    }
}
