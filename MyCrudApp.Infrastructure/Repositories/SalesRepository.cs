
using Microsoft.EntityFrameworkCore;
using MyCrudApp.Core.Entities;
using MyCrudApp.Core.Interfaces;
using MyCrudApp.Infrastructure.Data;

namespace MyCrudApp.Infrastructure.Repositories
{
    public class SalesRepository : ISaleRepository
    {
        private readonly AppDbContext _context;
        public SalesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sale>> GetAllAsync()
        {
            return await _context.Sales.Include(x => x.Customer).Include(x => x.Items).ToListAsync();
        }

        public async Task<Sale> GetByIdAsync(int id)
        {
            return await _context.Sales.Include(x => x.Customer).Include(x => x.Items).AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(Sale sale)
        {
            await _context.Sales.AddAsync(sale);
        }
        public void Update(Sale sale)
        {
            _context.Sales.Update(sale);
        }

        public void Delete(Sale sale)
        {
            _context.Sales.Remove(sale);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0 ;
        }

    }
}
