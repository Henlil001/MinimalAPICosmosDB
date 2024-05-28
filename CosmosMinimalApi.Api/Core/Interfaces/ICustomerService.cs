using CosmosMinimalApi.Api.Domain;

namespace CosmosMinimalApi.Api.Core.Interfaces
{
    public interface ICustomerService
    {
        Task AddNewCustomer(Customer customer);
        Task<bool> UpdateCustomer(Customer customer);
        Task<bool> DeleteCustomer(Customer customer);
        Task<List<Customer>> GetCuustomersByName(string searchVal);
        Task<List<Customer>> GetCustomersBySalesPersonName(string searchVal);
    }
}
