using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            var newCustomer = new Customer
            {
                Name = customer.Name,
                Email = customer.Email,
                Age = customer.Age,
                CreatedAt = DateTime.Now,
            };
            await _customerRepository.AddCustomerAsync(newCustomer);
        }

        public async Task DeleteCustomerAsync(Guid id)
        {
            var getCustomerById = await _customerRepository.GetCustomerByIdAsync(id);
            await _customerRepository.DeleteCustomerAsync(getCustomerById.Id);
        }

        public async Task UpdateCustomerAsync(Guid id, Customer customer)
        {
            var getCustomerById = await _customerRepository.GetCustomerByIdAsync(id);
            getCustomerById.Name = customer.Name;
            getCustomerById.Email = customer.Email;
            getCustomerById.Age = customer.Age;
            await _customerRepository.UpdateCustomerAsync(id, getCustomerById);
        }
        public async Task<Customer> GetCustomerByIdAsync(Guid id)
        {
            return await _customerRepository.GetCustomerByIdAsync(id);
        }

        public async Task<List<Customer>> GetAllCustomerAsync()
        {
            return await _customerRepository.GetAllCustomerAsync();
        }
    }
}