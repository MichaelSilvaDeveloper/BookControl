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
    public class BookController : ControllerBase
    {

        private readonly IBookService _iBookService;

        private readonly IMapper _iMapper;

        public BookController(IBookService iBookService, IMapper iMapper)
        {
            _iBookService = iBookService;
            _iMapper = iMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var getAllBooks = await _iBookService.GetAllBooksAsync();
            var viewModel = _iMapper.Map<List<BookViewModel>> (getAllBooks);
            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var getBookById = await _iBookService.GetBookByIdAsync(id);
            if (getBookById == null)
            {
                return NotFound();
            }
            var viewModel = _iMapper.Map<BookViewModel>(getBookById);
            return Ok(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(BookInputModel bookInputModel)
        {
            var book = _iMapper.Map<Book>(bookInputModel);
            await _iBookService.AddBookAsync(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var getBookById = await _iBookService.GetBookByIdAsync(id);
            if (getBookById == null)
            {
                return NotFound();
            }
            await _iBookService.DeleteBookAsync(id);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBook(Guid id, BookInputModel bookInputModel)
        {
            var getBookById = await _iBookService.GetBookByIdAsync(id);
            if (getBookById == null)
            {
                return NotFound();
            }
            var book = _iMapper.Map<Book>(bookInputModel);
            await _iBookService.UpdateBooksAsync(id, book);
            return NoContent();
        }
    }
}