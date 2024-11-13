using MyCrudApp.Application.DTOs;
using MyCrudApp.Core.Entities;

namespace MyCrudApp.Application.Interfaces
{
    public interface ISalesService
    {
        Task<IEnumerable<Sale>> GetAllSalesAsync();
        Task<Sale> GetSaleByIdAsync(int id);
        Task<Sale> AddSaleAsync(CreateSaleDTO sale);
        Task UpdateSaleAsync(UpdateSaleDTO sale);
        Task DeleteSaleAsync(int id);
    }
}
