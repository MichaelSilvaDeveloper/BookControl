using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class BookLoanService : IBookLoanService
    {
        private readonly IBookLoanRepository _iBookLoanRepository;

        public BookLoanService(IBookLoanRepository iBookLoanRepository)
        {
            _iBookLoanRepository = iBookLoanRepository;
        }

        public async Task AddBookLoanAsync(BookLoan bookLoan)
        {
            var newBookLoan = new BookLoan
            {
                CustomerId = bookLoan.CustomerId,
                BookId = bookLoan.BookId,
                CreateAt = DateTime.Now,
            };

            await _iBookLoanRepository.AddBookLoanAsync(newBookLoan);         
        }
        public async Task UpdateBookLoanAsync(Guid id, BookLoan bookLoan)
        {
            var getBookLoan = await _iBookLoanRepository.GetBookLoanByIdAsync(id);
            getBookLoan.BookId = bookLoan.BookId;
            getBookLoan.CustomerId = bookLoan.CustomerId;
            await _iBookLoanRepository.UpdateBookLoanAsync(id, getBookLoan);
        }

        public async Task DeleteBookLoanByIdAsync(Guid id)
        {
            var getBookLoanById = await _iBookLoanRepository.GetBookLoanByIdAsync(id);
            await _iBookLoanRepository.DeleteBookLoanAsync(getBookLoanById.Id);
        }

        public async Task<BookLoan> GetBookLoanByIdAsync(Guid id)
        {
            return await _iBookLoanRepository.GetBookLoanByIdAsync(id);
        }

        public Task<List<BookLoan>> GetAllBookLoanAsync()
        {
            return _iBookLoanRepository.GetAllBookLoanAsync();
        }
    }
}