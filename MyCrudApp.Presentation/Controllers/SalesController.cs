using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCrudApp.Application.DTOs;
using MyCrudApp.Application.Interfaces;
using MyCrudApp.Core.Entities;
using MyCrudApp.Presentation.ViewModels;
using System.Globalization;

namespace MyCrudApp.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;
        private readonly IMapper _mapper;
        public SalesController(ISalesService salesService, IMapper mapper)
        {
            _salesService = salesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSales([FromQuery] string filter = null)
        {
            var sales = await _salesService.GetAllSalesAsync();
            var salesViewModel = _mapper.Map<List<GetAllSalesViewModel>>(sales);
            if (string.IsNullOrWhiteSpace(filter)) 
                return Ok(salesViewModel);

            var filteredSales = salesViewModel.Where(s =>
                (s.CustomerName.Contains(filter, StringComparison.OrdinalIgnoreCase)) ||
                (s.TotalItems.ToString().Contains(filter.Trim())) ||
                (s.TotalPrice.ToString(CultureInfo.CreateSpecificCulture("pt-BR")).Contains(filter.Trim())) ||
                (s.SaleDate.ToString("dd/MM/yyyy").Contains(filter.Trim())) ||
                (s.BillingDate.ToString("dd/MM/yyyy").Contains(filter.Trim())));
            return Ok(filteredSales);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSale(int id)
        {
            var sale = await _salesService.GetSaleByIdAsync(id);
            if (sale == null)
                return NotFound();
            var saleViewModel = _mapper.Map<GetSalesByIdViewModel>(sale);
            return Ok(saleViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSale([FromBody] CreateSaleDTO sale)
        {
            var newSale = await _salesService.AddSaleAsync(sale);
            return CreatedAtAction(nameof(GetSale), new { id = newSale.Id }, newSale);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSale(int id, [FromBody] UpdateSaleDTO sale)
        {
            if (id != sale.Id) 
                return BadRequest();
            await _salesService.UpdateSaleAsync(sale);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSale(int id)
        {
            var existingSale = await _salesService.GetSaleByIdAsync(id);
            if (existingSale == null)
                return NotFound();

            await _salesService.DeleteSaleAsync(id);
            return NoContent();
        }
    }
    
}
