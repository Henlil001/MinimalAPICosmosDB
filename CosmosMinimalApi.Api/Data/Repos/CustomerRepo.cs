using CosmosMinimalApi.Api.Data.Interfaces;
using CosmosMinimalApi.Api.Domain;

namespace CosmosMinimalApi.Api.Data.Repos
{
    public class CustomerRepo : ICustomerRepo
    {
        public Task AddNewCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerById(string id)
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
