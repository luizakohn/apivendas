using Microsoft.EntityFrameworkCore;
using MyCrudApp.Core.Entities;
using MyCrudApp.Core.Interfaces;
using MyCrudApp.Infrastructure.Data;

namespace MyCrudApp.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context) 
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.Where(c => c.IsActive).ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
        public bool CustomerHasSale(int id)
        {
            return _context.Customers.Where(c => c.Id ==id).Any(c => c.Sales.Count > 0);
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }   
    }
}
