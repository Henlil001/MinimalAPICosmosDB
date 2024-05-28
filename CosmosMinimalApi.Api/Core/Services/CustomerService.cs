using CosmosMinimalApi.Api.Core.Interfaces;
using CosmosMinimalApi.Api.Domain;

namespace CosmosMinimalApi.Api.Core.Services
{
    public class CustomerService : ICustomerService
    {
        public Task AddNewCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetCustomersBySalesPersonName(string searchVal)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetCuustomersByName(string searchVal)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
