using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BookControlContext _bookContext;

        public CustomerRepository(BookControlContext bookContext)
        {
            _bookContext = bookContext;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await _bookContext.Customers.AddAsync(customer);
            await _bookContext.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(Guid id)
        {
            var customer = await GetCustomerByIdAsync(id);
            _bookContext.Customers.Remove(customer);
            await _bookContext.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(Guid id, Customer customer)
        {
            var getCustomerByid = await GetCustomerByIdAsync(id);
            _bookContext.Customers.Update(getCustomerByid);
            await _bookContext.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid id)
        {
            return await _bookContext.Customers.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Customer>> GetAllCustomerAsync()
        {
            return await _bookContext.Customers.ToListAsync();
        }
    }
}