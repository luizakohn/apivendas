using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCrudApp.Application.DTOs;
using MyCrudApp.Application.Interfaces;
using MyCrudApp.Core.Entities;
using MyCrudApp.Presentation.ViewModels;

namespace MyCrudApp.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers([FromQuery] string filter = null)
        {
            try
            {
                var customers = await _customerService.GetAllCustomersAsync(filter);
                return Ok(customers);
            }
            catch (InvalidOperationException) 
            { 
                return NoContent();
            }
            
        }
        [HttpGet("combo")]
        public async Task<ActionResult<IEnumerable<CustomerComboViewModel>>> GetCustomerNameAndId()
        {
            try
            {
                var customers = await _customerService.GetAllCustomersAsync(null);
                var nameCustomers = _mapper.Map<List<CustomerComboViewModel>>(customers);
                return Ok(nameCustomers);
            }
            catch (InvalidOperationException)
            {
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCustomer([FromBody] CreateCustomerDTO customer)
        {
            var newCustomer = await _customerService.AddCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = newCustomer.Id }, newCustomer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer(int id, [FromBody] UpdateCustomerDTO customer)
        {
            if (id != customer.Id)
                return BadRequest();
            try
            {
                await _customerService.UpdateCustomerAsync(customer);
            }
            catch (InvalidOperationException ex) {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            try
            {
                await _customerService.DeleteCustomerAsync(id);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
            return NoContent();
        }
    }
}
