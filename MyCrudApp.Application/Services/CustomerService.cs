using AutoMapper;
using MyCrudApp.Application.DTOs;
using MyCrudApp.Application.Interfaces;
using MyCrudApp.Core.Entities;
using MyCrudApp.Core.Interfaces;
using System.Reflection;

namespace MyCrudApp.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Customer> AddCustomerAsync(CreateCustomerDTO customer)
        {
            var newCustomer = _mapper.Map<Customer>(customer);
            await _customerRepository.AddAsync(newCustomer);
            await _customerRepository.SaveChangesAsync();
            return newCustomer;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
                throw new InvalidOperationException($"Não foi encontrado cliente com id {id}.");
            if (_customerRepository.CustomerHasSale(id))
            {
                customer.IsActive = false;
                _customerRepository.Update(customer);
            }
            else
            {
                _customerRepository.Delete(customer);
            }
            await _customerRepository.SaveChangesAsync();

        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync(string? filter)
        {
            var customers = await _customerRepository.GetAllAsync();
            if (customers == null)
                throw new InvalidOperationException(nameof(customers));
            if (string.IsNullOrWhiteSpace(filter))
                return (customers);

            var filteredCustomers = customers.Where(c => c.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(prop => prop.PropertyType != typeof(List<Sale>))
                .Any(prop => prop.GetValue(c)?.ToString().Contains(filter, StringComparison.OrdinalIgnoreCase) == true));
            return (filteredCustomers);
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task UpdateCustomerAsync(UpdateCustomerDTO customer)
        {
            var existingCustomer = await _customerRepository.GetByIdAsync(customer.Id);

            if (existingCustomer == null)
                throw new InvalidOperationException($"Não foi encontrado cliente com id {customer.Id}.");

            _mapper.Map(customer, existingCustomer);
            _customerRepository.Update(existingCustomer);
            await _customerRepository.SaveChangesAsync();
        }
    }
}
