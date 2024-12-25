using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface ILoanService
{
    Task AddLoanAsync(int userId, int bookId);
    Task<IEnumerable<Loan>> GetAllLoansAsync();
}