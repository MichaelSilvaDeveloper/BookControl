using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BookLoanRepository : IBookLoanRepository
    {
        private readonly BookControlContext _bookContext;

        public BookLoanRepository(BookControlContext bookContext)
        {
            _bookContext = bookContext;
        }

        public async Task AddBookLoanAsync(BookLoan bookLoan)
        {
            await _bookContext.BookLoans.AddAsync(bookLoan);
            await _bookContext.SaveChangesAsync();
        }
        public async Task UpdateBookLoanAsync(Guid id, BookLoan bookLoan)
        {
            var getBookLoanById = await GetBookLoanByIdAsync(id);
            _bookContext.Update(getBookLoanById);
            await _bookContext.SaveChangesAsync();
        }

        public async Task DeleteBookLoanAsync(Guid id)
        {
            var getBookLoanById = await GetBookLoanByIdAsync(id);
            _bookContext.Remove(getBookLoanById);
            await _bookContext.SaveChangesAsync();
        }

        public async Task<BookLoan> GetBookLoanByIdAsync(Guid id)
        {
            return await _bookContext.BookLoans.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<BookLoan>> GetAllBookLoanAsync()
        {
            return await _bookContext.BookLoans.Include(x => x.Book)
                                                .Include(x => x.Customer)
                                                .ToListAsync();
        }      
    }
}