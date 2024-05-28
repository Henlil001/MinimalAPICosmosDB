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

            //Detta g�r l�sningen till minimal api
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

            //H�r l�gger jag till mina Endpoints
            await app.AddCustomerEndpointsAsync();

            await app.RunAsync();
        }
    }
}
