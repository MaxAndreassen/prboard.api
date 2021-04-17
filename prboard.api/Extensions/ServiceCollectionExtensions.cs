using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using prboard.api.data;

namespace prboard.api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDbContextConfiguration(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            
            services.AddDbContext<PrBoardDbContext>(options =>
            {
                options
                    .UseLazyLoadingProxies()
                    .UseMySql(connectionString, o => o.EnableRetryOnFailure())
                    .EnableDetailedErrors();
            });

            return services;
        }
        
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("All", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            return services;
        }
    }
}
