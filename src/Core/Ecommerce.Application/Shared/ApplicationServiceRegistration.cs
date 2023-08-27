using Ecommerce.Application.MappingProfiles;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ecommerce.Application.Shared
{
    public static class ApplicationServiceRegistration
    {
        public static void ConfigureApplicationService(this IServiceCollection services)
        {
            // Configure Automapper
            services.AddAutoMapper(typeof(CategoryMappingProfile));
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            
        }
    }
}
