using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ProductDbContext context) : base(context)
        {
        }

        public async Task<Product> GetProductoByNombre(string nameProduct)
        {
            return await _context.Product!.Where(o => o.Name == nameProduct).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductoByUserName(string username)
        {
            return await _context.Product!.Where(v => v.CreatedBy == username).ToListAsync();
        }
    }
}
