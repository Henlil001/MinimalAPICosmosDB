using CosmosMinimalApi.Api.Data;
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

            //Detta genererar en json fil varjeg�ng projektet byggs
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            //Detta g�r att vi kan se Swagger i webbl�saren och kan se UI och testa endpoints
            app.UseSwagger();
            app.UseSwaggerUI();

           // l�gg in mina endpoints h�r

           await app.RunAsync();
        }
    }
}
