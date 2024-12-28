using System.Linq.Expressions;
using FluentAssertions;
using Library.Application.Interfaces;
using Library.Application.Services;
using Library.Domain.Entities;
using Moq;

namespace Library.Tests.Services;

public class UserServiceTests
{
    private readonly Mock<IRepository<User>> _mockUserRepository;
    private readonly UserService _userService;

    public UserServiceTests()
    {
        _mockUserRepository = new Mock<IRepository<User>>();
        _userService = new UserService(_mockUserRepository.Object);
    }
    
    [Fact]
    public async Task AddUserAsync_ShouldAddUser_WhenDataIsValid()
    {
        var user = new User { Name = "John Doe", Email = "john.doe@example.com" };

        _mockUserRepository
            .Setup(repo => repo.FindAsync(It.IsAny<Expression<Func<User, bool>>>()))
            .ReturnsAsync([]);

        _mockUserRepository
            .Setup(repo => repo.AddAsync(It.IsAny<User>()))
            .Returns(Task.CompletedTask);

        await _userService.AddUserAsync(user);

        _mockUserRepository.Verify(repo => repo.AddAsync(It.Is<User>(u =>
            u.Name == "John Doe" && u.Email == "john.doe@example.com")), Times.Once);
    }

    [Fact]
    public async Task AddUserAsync_ShouldThrowException_WhenUserNameOrEmailIsInvalid()
    {
        var user = new User { Name = " ", Email = null };

        var act = async () => await _userService.AddUserAsync(user);

        await act.Should().ThrowAsync<ArgumentNullException>()
            .WithMessage("*cannot be null*");
    }

    [Fact]
    public async Task AddUserAsync_ShouldThrowException_WhenEmailAlreadyExists()
    {
        var user = new User { Name = "John Doe", Email = "john.doe@example.com" };
        
        _mockUserRepository
            .Setup(repo => repo.FindAsync(It.IsAny<Expression<Func<User, bool>>>()))
            .ReturnsAsync(new List<User> { new User { Email = "john.doe@example.com" } });

        var act = async () => await _userService.AddUserAsync(user);

        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("A user with the same email already exists.");
    }

    [Fact]
    public async Task GetAllUsersAsync_ShouldReturnAllUsers()
    {
        var users = new List<User>
        {
            new User { Name = "John Doe", Email = "john.doe@example.com" },
            new User { Name = "Jane Doe", Email = "jane.doe@example.com" }
        };

        _mockUserRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(users);

        var result = await _userService.GetAllUsersAsync();

        result.Should().BeEquivalentTo(users);
        _mockUserRepository.Verify(repo => repo.GetAllAsync(), Times.Once);
    }
}