using MyCrudApp.Application.DTOs;
using MyCrudApp.Core.Entities;

namespace MyCrudApp.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync(string? filter);
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<Customer> AddCustomerAsync(CreateCustomerDTO customer);
        Task UpdateCustomerAsync(UpdateCustomerDTO customer);
        Task DeleteCustomerAsync(int id);
    }
}
