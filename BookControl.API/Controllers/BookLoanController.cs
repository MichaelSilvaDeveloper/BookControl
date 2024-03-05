using Application.Interfaces;
using Application.Models.InputModels;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookLoanController : ControllerBase
    {
        private readonly IBookLoanService _iBookLoanService;

        private readonly IBookService _iBookService;

        private readonly ICustomerService _iCustomerService;

        private readonly IMapper _iMapper;


        public BookLoanController(IBookLoanService iBookLoanService, IBookService iBookService, ICustomerService iCustomerService, IMapper iMapper)
        {
            _iBookLoanService = iBookLoanService;
            _iBookService = iBookService;
            _iCustomerService = iCustomerService;
            _iMapper = iMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookLoan()
        {
            return Ok(await _iBookLoanService.GetAllBookLoanAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookLoanById(Guid id)
        {
            var getBookLoan = await _iBookLoanService.GetBookLoanByIdAsync(id);
            if (getBookLoan == null)
            {
                return NotFound();
            }
            var viewModel = _iMapper.Map<BookLoan>(getBookLoan);
            return Ok(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookLoan(BookLoanInputModel bookLoanInputModel)
        {
            var getCustomerById = await _iCustomerService.GetCustomerByIdAsync(bookLoanInputModel.CustomerId);

            var getBookById = await _iBookService.GetBookByIdAsync(bookLoanInputModel.BookId);
          
            if (getBookById == null || getCustomerById == null)
            {
                return NotFound("Livro ou Usuario inexistentes");
            }
            var bookLoan = _iMapper.Map<BookLoan>(bookLoanInputModel);
            await _iBookLoanService.AddBookLoanAsync(bookLoan);
            return CreatedAtAction(nameof(GetBookLoanById), new { id = bookLoan.Id }, bookLoan);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBookLoan(Guid id, BookLoanInputModel bookLoanInputModel)
        {
            var getBookLoan = await _iBookLoanService.GetBookLoanByIdAsync(id);
            if (getBookLoan == null)
            {
                return NotFound();
            }
            var bookLoan = _iMapper.Map<BookLoan>(bookLoanInputModel);
            await _iBookLoanService.UpdateBookLoanAsync(id, bookLoan);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookLoan(Guid id)
        {
            var getBookLoanById = await _iBookLoanService.GetBookLoanByIdAsync(id);
            if (getBookLoanById == null)
            {
                return NotFound();  
            }
            await _iBookLoanService.DeleteBookLoanByIdAsync(id);
            return NoContent();
        }
    }
}