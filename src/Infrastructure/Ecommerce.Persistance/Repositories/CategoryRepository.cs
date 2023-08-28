using Ecommerce.Application.Persistance.Contracts;
using Ecommerce.Domain.Entities;
using Ecommerce.Persistance.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistance.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context): base(context)
        {
            
        }
    }
}
