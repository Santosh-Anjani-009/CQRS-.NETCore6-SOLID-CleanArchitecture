using Ecommerce.Application.Persistance.Email;
using Ecommerce.Infrastructure.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infrastructure.Shared
{
    public static class InfrastructureServiceRegistration
    {
        public static void ConfigureInfrastructureService(this IServiceCollection services, IConfiguration configuration) 
        {
            services.Configure<EmailSender>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailSender, EmailSender>();
        }
    }
}
