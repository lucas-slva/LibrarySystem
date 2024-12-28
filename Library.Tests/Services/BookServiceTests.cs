using FluentAssertions;
using Library.Application.Interfaces;
using Library.Application.Services;
using Library.Domain.Entities;
using Moq;

namespace Library.Tests.Services;

public class BookServiceTests
{
    private readonly Mock<IRepository<Book>> _mockRepository;
    private readonly BookService _bookService;

    public BookServiceTests()
    {
        _mockRepository = new Mock<IRepository<Book>>();
        _bookService = new BookService(_mockRepository.Object);
    }

    [Fact]
    public async Task AddBookAsync_ValidBook_ShouldReturnTrue()
    {
        var book = new Book
        {
            Title = "Clean Code",
            Author = "Robert C. Martin",
            Isbn = "9780132350884",
            PublishDate = DateTime.Now
        };
        
        _mockRepository
            .Setup(repo => repo.AddAsync(It.IsAny<Book>()))
            .Returns(Task.CompletedTask);
        
        await _bookService.AddBookAsync(book);
        
        _mockRepository.Verify(repo => repo.AddAsync(book), Times.Once);
    }

    [Fact]
    public async Task AddBookAsync_NullBook_ShouldReturnFalse()
    {
        var book = new Book
        {
            Title = "Clean Code",
            Author = "Robert C. Martin",
            Isbn = "", // invalid ISBN
            PublishDate = DateTime.Now
        };
        
        var act = async () => await _bookService.AddBookAsync(book);
        
        await act.Should().ThrowAsync<ArgumentNullException>("Book ISBN cannot be empty.");
    }
}