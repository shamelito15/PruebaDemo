using MediatR;

namespace CleanArchitecture.Application.Features.Products.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<List<ProductVm>>
    {
        public string _Username { get; set; }
        public GetProductListQuery(string username)
        {
            _Username = username ?? throw new ArgumentNullException(nameof(username));
        }
    }
}
