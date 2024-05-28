using CosmosMinimalApi.Api.Core.Interfaces;
using CosmosMinimalApi.Api.Data;
using CosmosMinimalApi.Api.Endpoints;
using CosmosMinimalApi.Api.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

namespace CosmosMinimalApi.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();//Detta gör lösningen till minimal api
            builder.Services.AddSwaggerGen();

            await builder.AddKeyvaultExtendedAsync();

            builder.Services.AddDbContext<CustomerDbContext>();
            builder.Services.AddScopedExtension();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            var customerService = app.Services.GetRequiredService<ICustomerService>();
            app.AddCustomerEndpoints(customerService);
            await app.RunAsync();
        }
    }
}
