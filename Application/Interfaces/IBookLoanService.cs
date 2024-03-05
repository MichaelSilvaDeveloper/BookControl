using Domain.Entities;

namespace Application.Interfaces
{
    public interface IBookLoanService
    {
        Task AddBookLoanAsync(BookLoan bookLoan);

        Task UpdateBookLoanAsync(Guid id, BookLoan bookLoan);

        Task DeleteBookLoanByIdAsync(Guid id);

        Task<BookLoan> GetBookLoanByIdAsync(Guid id);

        Task<List<BookLoan>> GetAllBookLoanAsync();
    }
}