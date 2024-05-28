﻿using CosmosMinimalApi.Api.Data.Interfaces;
using CosmosMinimalApi.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace CosmosMinimalApi.Api.Data.Repos
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly CustomerDbContext _context;
        public CustomerRepo(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task AddNewCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteCustomerAsync(Customer customer)
        {
            try
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<Customer?> GetCustomerByIdAsync(string id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.id == id);
            return customer;
        }

        public async Task<List<Customer>> GetCustomersBySalesPersonNameAsync(string searchVal)
        {
            var customers = await _context.Customers
                                 .Where(c => c.SalesPersonName.Contains(searchVal))
                                 .AsNoTracking().ToListAsync();
            return customers;
        }

        public async Task<List<Customer>> GetCustomersByNameAsync(string searchVal)
        {
            var customers = await _context.Customers
                .Where(c => c.Name.Contains(searchVal))
                .AsNoTracking().ToListAsync();
            return customers;
        }

        public async Task<bool> UpdateCustomerAsync(Customer updatedCustomer, Customer customer)
        {
            try
            {
                _context.Entry(customer).CurrentValues.SetValues(updatedCustomer);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
