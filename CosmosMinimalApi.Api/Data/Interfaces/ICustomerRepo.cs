using CosmosMinimalApi.Api.Domain;

namespace CosmosMinimalApi.Api.Data.Interfaces
{
    public interface ICustomerRepo
    {
        Task AddNewCustomerAsync(Customer customer);
        Task<bool> UpdateCustomerAsync(Customer updatedCustomer, Customer customer);
        Task<bool> DeleteCustomerAsync(Customer customer);
        Task<Customer?> GetCustomerByIdAsync(string id);
        Task<List<Customer>> GetCustomersByNameAsync(string searchVal);
        Task<List<Customer>> GetCustomersBySalesPersonNameAsync(string searchVal);
    }
}
