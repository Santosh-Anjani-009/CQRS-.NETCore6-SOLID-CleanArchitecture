using Ecommerce.Application.Persistance.Contracts;
using Ecommerce.Domain.Entities;
using Ecommerce.Persistance.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistance.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsyncWithInclude()
        {
           var productWithCategory = await _context.Products.AsNoTracking().Include(x => x.Category).ToListAsync();

            return productWithCategory;
        }
    }
}
