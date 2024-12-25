using Library.Application.Helpers;
using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Services;

public class LoanService(
    IRepository<Loan> loanRepository, 
    IRepository<User> userRepository, 
    IRepository<Book> bookRepository) : ILoanService
{
    private readonly IRepository<Loan> _loanRepository = loanRepository;
    private readonly IRepository<User> _userRepository = userRepository;
    private readonly IRepository<Book> _bookRepository = bookRepository;
    
    public async Task AddLoanAsync(int userId, int bookId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        var book = await _bookRepository.GetByIdAsync(bookId);
        
        ValidationHelper.ValidateStrings(user, book);
        
        var activeLoan = await _loanRepository.FindAsync(l => l.BookId == bookId && l.ReturnDate == null);
        if (activeLoan.Any())
        {
            throw new InvalidOperationException("The book is already loaned.");
        }
        
        var loan = new Loan
        {
            UserId = userId,
            BookId = bookId,
            LoanDate = DateTime.Now
        };
        
        await _loanRepository.AddAsync(loan);
    }

    public async Task<IEnumerable<Loan>> GetAllLoansAsync()
    {
        return await _loanRepository.GetAllAsync();
    }
}