using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookControlContext _bookContext;

        public BookRepository(BookControlContext bookContext)
        {
            _bookContext = bookContext;
        }

        public async Task AddBookAsync(Book book)
        {
            await _bookContext.Books.AddAsync(book);
            await _bookContext.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(Guid id)
        {
            var book = await GetBookByIdAsync(id);
            _bookContext.Books.Remove(book);
            await _bookContext.SaveChangesAsync();
        }

        public async Task UpdateBooksAsync(Guid id, Book book)
        {
            var getBookById = await GetBookByIdAsync(id);
            _bookContext.Update(getBookById);
            await _bookContext.SaveChangesAsync();  
        }

        public async Task<Book> GetBookByIdAsync(Guid id)
        {
            return await _bookContext.Books.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _bookContext.Books.ToListAsync();
        }     
    }
}