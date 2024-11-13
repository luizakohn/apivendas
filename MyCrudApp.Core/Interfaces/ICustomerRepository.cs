using MyCrudApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCrudApp.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task AddAsync(Customer customer);
        bool CustomerHasSale(int id);
        void Update(Customer customer);
        void Delete(Customer customer);
        Task<bool> SaveChangesAsync();
    }
}
