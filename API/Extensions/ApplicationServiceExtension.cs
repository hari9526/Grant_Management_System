using API.Data;
using API.Interface;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenServices, TokenServices>();
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnnectionString"))
            );
            return services; 

        }
    }
}