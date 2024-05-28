using CosmosMinimalApi.Api.Data;
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

            //Detta genererar en json fil varjegång projektet byggs
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            //Detta gör att vi kan se Swagger i webbläsaren och kan se UI och testa endpoints
            app.UseSwagger();
            app.UseSwaggerUI();

           // lägg in mina endpoints här

           await app.RunAsync();
        }
    }
}
