using Library.Application.Helpers;
using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Services;

public class LoanService(
    IRepository<Loan> loanRepository,
    IRepository<Book> bookRepository,
    IRepository<User> userRepository)
    : ILoanService
{
    private readonly IRepository<Loan> _loanRepository = loanRepository ?? throw new ArgumentNullException(nameof(loanRepository));
    private readonly IRepository<User> _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    private readonly IRepository<Book> _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));

    public async Task AddLoanAsync(int userId, int bookId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        var book = await _bookRepository.GetByIdAsync(bookId);
        
        if (book == null)
        {
            throw new InvalidOperationException("Book cannot be null.");
        }

        if (user == null)
        {
            throw new InvalidOperationException("User cannot be null.");
        }
        
        var activeLoan = await _loanRepository.FirstOrDefaultAsync(l => l.BookId == bookId && l.ReturnDate == null);
        if (activeLoan != null)
        {
            throw new InvalidOperationException("The book is already borrowed.");
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