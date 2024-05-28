namespace CosmosMinimalApi.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //Detta gör lösningen till minimal api
            builder.Services.AddEndpointsApiExplorer();

            //Detta genererar en json fil varjegång projektet byggs
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            //Detta gör att vi kan se Swagger i webbläsaren och kan se UI och testa endpoints
            app.UseSwagger();
            app.UseSwaggerUI();

           // lägg in mina endpoints här

            app.Run();
        }
    }
}
