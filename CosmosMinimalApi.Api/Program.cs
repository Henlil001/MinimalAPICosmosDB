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

            builder.Services.AddDbContextExtended();
            builder.Services.AddScopedExtension();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

           
                app.AddCustomerEndpoints();
           

            await app.RunAsync();
        }
    }
}
