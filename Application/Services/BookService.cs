using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _iBookRepository;

        public BookService(IBookRepository iBookRepository)
        {
            _iBookRepository = iBookRepository;
        }

        public async Task AddBookAsync(Book book)
        {
            var newBook = new Book
            {
                Title = book.Title,
                Author = book.Author,
                Isbn = book.Isbn,   
                PublicationYear = book.PublicationYear,
            };
            await _iBookRepository.AddBookAsync(newBook);
        }

        public async Task DeleteBookAsync(Guid id)
        {
            var getBook = await _iBookRepository.GetBookByIdAsync(id);



            await _iBookRepository.DeleteBookAsync(getBook.Id);          
        }

        public async Task UpdateBooksAsync(Guid id, Book book)
        {
            var getBook = await _iBookRepository.GetBookByIdAsync(id);
            getBook.Title = book.Title;
            getBook.Author = book.Author;
            getBook.Isbn = book.Isbn;   
            getBook.PublicationYear = book.PublicationYear;
            await _iBookRepository.UpdateBooksAsync(getBook.Id, getBook);
        }

        public async Task<Book> GetBookByIdAsync(Guid id)
        {
            return await _iBookRepository.GetBookByIdAsync(id);
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _iBookRepository.GetAllBooksAsync();
        }
    }
}