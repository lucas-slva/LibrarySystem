using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface IBookService
{
    Task AddBookAsync(Book book);
    Task<IEnumerable<Book>> GetAllBooksAsync();
    Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author);
}