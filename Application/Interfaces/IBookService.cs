using Domain.Entities;

namespace Application.Interfaces
{
    public interface IBookService
    {
        Task AddBookAsync(Book book);

        Task DeleteBookAsync(Guid id);

        Task UpdateBooksAsync(Guid id, Book book);

        Task<Book> GetBookByIdAsync(Guid id);

        Task<List<Book>> GetAllBooksAsync();
    }
}