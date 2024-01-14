using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
            Task<Product> GetProductoByNombre(string nameProduct);
        Task<IEnumerable<Product>> GetProductoByUserName(string username);
    }
}
