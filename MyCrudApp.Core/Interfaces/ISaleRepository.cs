using MyCrudApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCrudApp.Core.Interfaces
{
    public interface ISaleRepository
    {
        Task<IEnumerable<Sale>> GetAllAsync();
        Task<Sale> GetByIdAsync(int id);
        Task AddAsync(Sale sale);
        void Update(Sale sale);
        void Delete(Sale sale);
        Task<bool> SaveChangesAsync();
    }
}
