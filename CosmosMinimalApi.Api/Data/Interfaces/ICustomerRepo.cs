using CosmosMinimalApi.Api.Domain;

namespace CosmosMinimalApi.Api.Data.Interfaces
{
    public interface ICustomerRepo
    {
        Task AddNewCustomer(Customer customer);
        Task<bool> UpdateCustomer(Customer customer);
        Task<bool> DeleteCustomer(string id);
        Task<Customer> GetCustomerById(string id);
        Task<List<Customer>> GetCuustomersByName(string searchVal);
        Task<List<Customer>> GetCustomersBySalesPersonName(string searchVal);
    }
}
