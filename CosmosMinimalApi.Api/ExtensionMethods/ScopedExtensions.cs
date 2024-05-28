using CosmosMinimalApi.Api.Core.Interfaces;
using CosmosMinimalApi.Api.Core.Services;
using CosmosMinimalApi.Api.Data.Interfaces;
using CosmosMinimalApi.Api.Data.Repos;

namespace CosmosMinimalApi.Api.ExtensionMethods
{
    public static class ScopedExtensions
    {
        public static IServiceCollection AddScopedExtension(this IServiceCollection service)
        {
            service.AddScoped<ICustomerRepo, CustomerRepo>();
            service.AddScoped<ICustomerService, CustomerService>();

            return service;
        }
    }
}
