using Application.Interfaces;
using Application.Models.InputModels;
using Application.Models.ViewModels;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        
        private readonly ICustomerService _iCustomerService;

        private readonly IMapper _iMapper;

        public CustomerController(ICustomerService iCustomerService, IMapper iMapper)
        {
            _iCustomerService = iCustomerService;
            _iMapper = iMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var getAllCustomers = await _iCustomerService.GetAllCustomerAsync();
            var viewModel = _iMapper.Map<List<CustomerViewModel>>(getAllCustomers);
            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            var getCustomer = await _iCustomerService.GetCustomerByIdAsync(id);
            if (getCustomer == null)
            {
                return NotFound();
            }
            var viewModel = _iMapper.Map<CustomerViewModel>(getCustomer);
            return Ok(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerInputModel customerInputModel)
        {
            var customer = _iMapper.Map<Customer>(customerInputModel);
            await _iCustomerService.AddCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCustomer(Guid id, CustomerInputModel customerInputModel)
        {
            var getcustomer = await _iCustomerService.GetCustomerByIdAsync(id);
            if (getcustomer == null)
            {
                return NotFound();
            }
            var customer = _iMapper.Map<Customer>(customerInputModel); 
            await _iCustomerService.UpdateCustomerAsync(id, customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var getcustomer = await _iCustomerService.GetCustomerByIdAsync(id);
            if (getcustomer == null)
            {
                return NotFound();
            }
            await _iCustomerService.DeleteCustomerAsync(getcustomer.Id);
            return NoContent();
        }       
    }
}