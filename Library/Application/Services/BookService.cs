using Library.Application.Helpers;
using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Services;

public class BookService(IRepository<Book> repository) : IBookService
{
    private readonly IRepository<Book> _repository = repository;

    public async Task AddBookAsync(Book book)
    {
        ValidationHelper.ValidateStrings(
            (book.Title, nameof(book.Title)),
            (book.Author, nameof(book.Author)),
            (book.Isbn, nameof(book.Isbn)));
        
        var existingBook = await _repository.FindAsync(b => b.Isbn == book.Isbn);
        if (existingBook.Any())
        {
            throw new InvalidOperationException("A book with the same ISBN already exists.");
        }
        
        await _repository.AddAsync(book);
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author)
    {
        return await _repository.FindAsync(b => b.Author == author);
    }
}