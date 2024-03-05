using Domain.Entities;


namespace Domain.Interfaces
{
    public interface IBookLoanRepository
    {
        Task AddBookLoanAsync(BookLoan bookLoan);

        Task UpdateBookLoanAsync(Guid id, BookLoan bookLoan);

        Task DeleteBookLoanAsync(Guid id);

        Task<BookLoan> GetBookLoanByIdAsync(Guid id);

        Task<List<BookLoan>> GetAllBookLoanAsync();
    }
}