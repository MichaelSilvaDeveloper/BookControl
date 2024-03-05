using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICustomerService
    {
        Task AddCustomerAsync(Customer customer);

        Task DeleteCustomerAsync(Guid id);

        Task UpdateCustomerAsync(Guid id, Customer customer);

        Task<Customer> GetCustomerByIdAsync(Guid id);

        Task<List<Customer>> GetAllCustomerAsync();
    }
}