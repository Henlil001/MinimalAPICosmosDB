using CosmosMinimalApi.Api.Domain;

namespace CosmosMinimalApi.Api.Core.Interfaces
{
    public interface ICustomerService
    {
        Task AddNewCustomerAsync(Customer customer);
        Task<bool> UpdateCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(string id);
        Task<List<Customer>> GetCustomersByNameAsync(string searchVal);
        Task<List<Customer>> GetCustomersBySalesPersonNameAsync(string searchVal);
    }
}
