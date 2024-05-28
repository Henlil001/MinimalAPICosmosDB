using CosmosMinimalApi.Api.Core.Interfaces;
using CosmosMinimalApi.Api.Data.Interfaces;
using CosmosMinimalApi.Api.Data.Repos;
using CosmosMinimalApi.Api.Domain;
using Microsoft.Azure.Cosmos.Linq;

namespace CosmosMinimalApi.Api.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomerService(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }


        public async Task AddNewCustomerAsync(Customer customer)
        {
            customer.id = Guid.NewGuid().ToString();
            await _customerRepo.AddNewCustomerAsync(customer);
        }

        public async Task<bool> DeleteCustomerAsync(string id)
        {
           var selectedCustumer = await _customerRepo.GetCustomerByIdAsync(id);
            return selectedCustumer != null? await _customerRepo.DeleteCustomerAsync(selectedCustumer): false; 
        }

        public async Task<List<Customer>> GetCustomersBySalesPersonNameAsync(string searchVal)
        {
            return await _customerRepo.GetCustomersBySalesPersonNameAsync(searchVal);
        }

        public async Task<List<Customer>> GetCustomersByNameAsync(string searchVal)
        {
           return await _customerRepo.GetCustomersByNameAsync(searchVal);
        }

        public async Task<bool> UpdateCustomerAsync(Customer updatedCustomer)
        {
            var selectedCustomer = await _customerRepo.GetCustomerByIdAsync(updatedCustomer.id);
            return selectedCustomer != null? await _customerRepo.UpdateCustomerAsync(updatedCustomer, selectedCustomer) : false;
        }
    }
}
