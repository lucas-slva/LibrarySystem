using FluentAssertions;
using Library.Application.Interfaces;
using Library.Application.Services;
using Library.Domain.Entities;
using Moq;

namespace Library.Tests.Services;

public class LoanServiceTests
{
    private readonly Mock<IRepository<Loan>> _mockLoanRepository;
    private readonly Mock<IRepository<Book>> _mockBookRepository;
    private readonly Mock<IRepository<User>> _mockUserRepository;
    private readonly LoanService _loanService;

    public LoanServiceTests()
    {
        _mockLoanRepository = new Mock<IRepository<Loan>>();
        _mockBookRepository = new Mock<IRepository<Book>>();
        _mockUserRepository = new Mock<IRepository<User>>();

        _loanService = new LoanService(
            _mockLoanRepository.Object,
            _mockBookRepository.Object,
            _mockUserRepository.Object
        );
    }

    [Fact]
    public async Task CreateLoanAsync_ShouldCreateLoan_WhenDataIsValid()
    {
        var book = new Book
        {
            Id = 1,
            Title = "Clean Code",
            Isbn = "9780132350884"
        };

        var user = new User
        {
            Id = 1,
            Name = "John Doe"
        };

        _mockBookRepository.Setup(repo => repo.GetByIdAsync(book.Id)).ReturnsAsync(book);
        _mockUserRepository.Setup(repo => repo.GetByIdAsync(user.Id)).ReturnsAsync(user);
        _mockLoanRepository.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Func<Loan, bool>>()))
            .ReturnsAsync((Loan?)null);
        _mockLoanRepository.Setup(repo => repo.AddAsync(It.IsAny<Loan>()))
            .Returns(Task.CompletedTask);

        await _loanService.AddLoanAsync(user.Id, book.Id);

        _mockLoanRepository.Verify(repo => repo.AddAsync(It.Is<Loan>(loan =>
            loan.BookId == book.Id &&
            loan.UserId == user.Id &&
            loan.LoanDate.Date == DateTime.Now.Date)), Times.Once);
    }

    [Fact]
    public async Task CreateLoanAsync_ShouldThrowException_WhenBookIsNull()
    {
        _mockBookRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((Book?)null);

        var act = async () => await _loanService.AddLoanAsync(1, 999);

        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("Book cannot be null.");
    }

    [Fact]
    public async Task CreateLoanAsync_ShouldThrowException_WhenUserIsNull()
    {
        var book = new Book { Id = 1, Title = "Clean Code", Isbn = "9780132350884" };

        _mockBookRepository.Setup(repo => repo.GetByIdAsync(book.Id))
            .ReturnsAsync(book);
        _mockUserRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((User?)null);

        var act = async () => await _loanService.AddLoanAsync(999, book.Id);

        // Assert
        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("User cannot be null.");
    }

    [Fact]
    public async Task CreateLoanAsync_ShouldThrowException_WhenBookIsAlreadyBorrowed()
    {
        var book = new Book { Id = 1, Title = "Clean Code", Isbn = "9780132350884" };
        var user = new User { Id = 1, Name = "John Doe" };
        var activeLoan = new Loan { BookId = book.Id, UserId = user.Id, LoanDate = DateTime.Now };

        _mockBookRepository.Setup(repo => repo.GetByIdAsync(book.Id))
            .ReturnsAsync(book);
        _mockUserRepository.Setup(repo => repo.GetByIdAsync(user.Id))
            .ReturnsAsync(user);
        _mockLoanRepository.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Func<Loan, bool>>()))
            .ReturnsAsync(activeLoan);

        var act = async () => await _loanService.AddLoanAsync(user.Id, book.Id);

        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("The book is already borrowed.");
    }
}