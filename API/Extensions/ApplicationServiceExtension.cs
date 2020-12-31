
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
            //Business layer
            services.AddTransient<IUser, User>();
            services.AddTransient<IGrants, Grants>();
            services.AddTransient<IReview, Review>();
            services.AddTransient<IEducation, Education>();
            services.AddTransient<IApplicant, Applicant>();
            
            //Data access layer
            services.AddTransient<IUserRepository, UserRepository>();            
            services.AddTransient<IGrantsRepository, GrantsRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IEducationDetailsRepository, EducationDetailsRepository>();
            services.AddTransient<IApplicantRepository, AppicantRepository>();

            
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnnectionString"))
            );
            return services; 

        }
    }
}