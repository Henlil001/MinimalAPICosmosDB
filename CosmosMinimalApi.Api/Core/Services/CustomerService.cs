using CosmosMinimalApi.Api.Core.Interfaces;
using CosmosMinimalApi.Api.Data.Interfaces;
using CosmosMinimalApi.Api.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmosMinimalApi.Api.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _customerRepo;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(ICustomerRepo customerRepo, ILogger<CustomerService> logger)
        {
            _customerRepo = customerRepo;
            _logger = logger;
        }

        public async Task AddNewCustomerAsync(Customer customer)
        {
            try
            {
                customer.id = Guid.NewGuid().ToString();
                await _customerRepo.AddNewCustomerAsync(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to add a new customer");
                throw;
            }
        }

        public async Task<bool> DeleteCustomerAsync(string id)
        {
            try
            {
                var selectedCustomer = await _customerRepo.GetCustomerByIdAsync(id);
                return selectedCustomer != null ? await _customerRepo.DeleteCustomerAsync(selectedCustomer) : false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to delete a customer");
                throw;
            }
        }

        public async Task<List<Customer>> GetCustomersBySalesPersonNameAsync(string searchVal)
        {
            try
            {
                return await _customerRepo.GetCustomersBySalesPersonNameAsync(searchVal);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to get customers by salesperson name");
                throw;
            }
        }

        public async Task<List<Customer>> GetCustomersByNameAsync(string searchVal)
        {
            try
            {
                return await _customerRepo.GetCustomersByNameAsync(searchVal);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to get customers by name");
                throw;
            }
        }

        public async Task<bool> UpdateCustomerAsync(Customer updatedCustomer)
        {
            try
            {
                var selectedCustomer = await _customerRepo.GetCustomerByIdAsync(updatedCustomer.id);
                return selectedCustomer != null ? await _customerRepo.UpdateCustomerAsync(updatedCustomer, selectedCustomer) : false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to update a customer");
                throw;
            }
        }
    }
}
