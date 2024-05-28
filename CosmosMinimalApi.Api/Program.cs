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

            //Detta gör lösningen till minimal api
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddDbContext<CustomerDbContext>(options =>
               options.UseCosmos("",//URI
                                    "",//Primary Key
                                    ""//DatabaseName
                                    ));

            builder.Services.AddSwaggerGen();

            builder.Services.AddScopedExtension();

            var app = builder.Build();


            app.UseSwagger();
            app.UseSwaggerUI();

            //Här lägger jag till mina Endpoints
            var customerService = app.Services.GetRequiredService<ICustomerService>();
            app.AddCustomerEndpoints(customerService);

            await app.RunAsync();
        }
    }
}
