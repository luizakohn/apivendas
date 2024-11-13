using AutoMapper;
using MyCrudApp.Application.DTOs;
using MyCrudApp.Application.Interfaces;
using MyCrudApp.Core.Entities;
using MyCrudApp.Core.Interfaces;

namespace MyCrudApp.Application.Services
{
    public class SalesService : ISalesService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        public SalesService(ISaleRepository saleRepository, IMapper mapper) 
        { 
            _saleRepository = saleRepository;
            _mapper = mapper;
        }
        public async Task<Sale> AddSaleAsync(CreateSaleDTO sale)
        {
            var newSale = _mapper.Map<Sale>(sale);
            await _saleRepository.AddAsync(newSale);
            await _saleRepository.SaveChangesAsync();
            return newSale;
        }

        public async Task DeleteSaleAsync(int id)
        {
            var sale = await _saleRepository.GetByIdAsync(id);
            if (sale != null)
            {
                _saleRepository.Delete(sale);
                await _saleRepository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Sale>> GetAllSalesAsync()
        {
            return await _saleRepository.GetAllAsync();
        }

        public Task<Sale> GetSaleByIdAsync(int id)
        {
            return _saleRepository.GetByIdAsync(id);
        }

        public async Task UpdateSaleAsync(UpdateSaleDTO sale)
        {
            var existingSale = await _saleRepository.GetByIdAsync(sale.Id);

            if (existingSale == null)
                throw new InvalidOperationException($"Não foi encontrada venda com id {sale.Id}.");

            _mapper.Map(sale, existingSale);

            foreach (var item in sale.Items)
            {
                if (!existingSale.Items.Any(x => x.Id == item.Id))
                {
                    existingSale.Items.Add(_mapper.Map<Item>(item));
                }
                else
                {
                    var updateItem = existingSale.Items.FirstOrDefault(x => x.Id == item.Id);
                    _mapper.Map(item, updateItem);
                }
            }

            List<Item> itemsToRemove = new List<Item>();
            foreach (var item in existingSale.Items)
            {
                if (!sale.Items.Any(x => x.Id == item.Id))
                {
                    itemsToRemove.Add(item);
                }
            }

            foreach (var item in itemsToRemove)
            {
                existingSale.Items.Remove(item);
            }

            _saleRepository.Update(existingSale);
            await _saleRepository.SaveChangesAsync();
        }
    }
}
