using CosmosMinimalApi.Api.Core.Interfaces;
using CosmosMinimalApi.Api.Core.Services;
using CosmosMinimalApi.Api.Data.Repos;
using CosmosMinimalApi.Api.Domain;
using Microsoft.Azure.Cosmos.Serialization.HybridRow;

namespace CosmosMinimalApi.Api.Endpoints
{
    public static class CustomerEndpoints
    {
        
        public static WebApplication AddCustomerEndpoints(this WebApplication app)
        {
            
            //Lägga till kund
            app.MapPost("api/customer/add", async (Customer customer, ICustomerService _service) =>
            {
                await _service.AddNewCustomerAsync(customer);
                return Results.Created($"/api/customer/{customer.id}", customer);
            });

            //Uppdatera kund
            app.MapPut("api/customer/update", async (Customer customer, ICustomerService _service) =>
            {
                bool result = await _service.UpdateCustomerAsync(customer);
                return result is true ? Results.Ok("Customer updated successfully") : Results.BadRequest("Customer do not exist");
            });

            //Ta bort kund
            app.MapDelete("api/customer/delete", async (string id, ICustomerService _service) =>
             {
                 bool result = await _service.DeleteCustomerAsync(id);
                 return result is true ? Results.Ok("Customer deleted successfully") : Results.BadRequest("Customer do not exist");
             });

            //Söka på kundens namn
            app.MapGet("api/customer/search", async (string searchVal, ICustomerService _service) =>
            {
                return Results.Ok(await _service.GetCustomersByNameAsync(searchVal));
            });

            //Söka på ansvarig säljares namn
            app.MapGet("api/customer/searh/salesperson", async (string searchVal, ICustomerService _service) =>
            {
                return Results.Ok(await _service.GetCustomersBySalesPersonNameAsync(searchVal));
            });

            return app;
        }
    }
}
