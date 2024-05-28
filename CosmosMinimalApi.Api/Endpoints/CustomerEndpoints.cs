using CosmosMinimalApi.Api.Domain;

namespace CosmosMinimalApi.Api.Endpoints
{
    public static class CustomerEndpoints
    {
        public static WebApplication AddCustomerEndpointsAsync(this WebApplication app)
        {
            //Lägga till kund
            app.MapPost("api/customer/add", (Customer customer) =>
            {

                return Results.Created();
            });

            //Uppdatera kund
            app.MapPut("api/customer/update", (Customer customer) =>
            {

                return Results.Ok("Customer updated successfully");
            });

            //Ta bort kund
            app.MapDelete("api/customer/delete", (string id) =>
            {
                return Results.Ok("Customer deleted successfully");
            });

            //Söka på kundens namn
            app.MapGet("api/customer/search", (string searchVal) =>
            {

                return Results.Ok();
            });

            //Söka på ansvarig säljares namn
            app.MapGet("api/customer/searh/salesperson", (string searchVal) =>
            {

                return Results.Ok();
            });

            return app;
        }
    }
}
