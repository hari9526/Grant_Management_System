
using API.Interface;
using API.Services;
using business.Implementations;
using business.Interfaces;
using data.Data;
using data.Implementations;
using data.Interfaces;
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
            services.AddTransient<IUser, User>();
            services.AddTransient<IGrants, Grants>();
            services.AddTransient<IReview, Review>();

            services.AddTransient<IUserRepository, UserRepository>();            
            services.AddTransient<IGrantsRepository, GrantsRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();

            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnnectionString"))
            );
            return services; 

        }
    }
}