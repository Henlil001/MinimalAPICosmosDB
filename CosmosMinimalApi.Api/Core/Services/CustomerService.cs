using CosmosMinimalApi.Api.Core.Interfaces;
using CosmosMinimalApi.Api.Domain;

namespace CosmosMinimalApi.Api.Core.Services
{
    public class CustomerService : ICustomerService
    {
        public Task AddNewCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCustomerAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetCustomersBySalesPersonNameAsync(string searchVal)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetCustomersByNameAsync(string searchVal)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
