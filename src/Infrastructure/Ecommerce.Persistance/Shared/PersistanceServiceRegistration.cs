using Ecommerce.Application.Persistance.Contracts;
using Ecommerce.Persistance.DatabaseContext;
using Ecommerce.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistance.Shared
{
    public static class PersistanceServiceRegistration
    {

        public static void ConfigurePersistanceService(this IServiceCollection services, IConfiguration configuration )
        {
            // configure AppDbContext
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            // Configure Service
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
