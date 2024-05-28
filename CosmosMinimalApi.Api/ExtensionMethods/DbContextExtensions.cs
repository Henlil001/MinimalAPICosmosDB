using CosmosMinimalApi.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace CosmosMinimalApi.Api.ExtensionMethods
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddDbContextExtended(this IServiceCollection services)
        {
            services.AddDbContext<CustomerDbContext>(options =>
           options.UseCosmos(
               Secrets.URI, // URI
               Secrets.PrimaryKey, // Primary key
               Secrets.DbName // Database name
           ));
            return services;
        }
    }
}
