using Library.Application.Helpers;
using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Services;

public class UserService(IRepository<User> repository) : IUserService
{
    private readonly IRepository<User> _repository = repository;
    
    public async Task AddUserAsync(User user)
    {
        ValidationHelper.ValidateStrings(
            (user.Name, nameof(user.Name)),
            (user.Email, nameof(user.Email)));

        var existingUser = await _repository.FindAsync(u => u.Email == user.Email);
        if (existingUser.Any())
        {
            throw new InvalidOperationException("A user with the same email already exists.");
        }

        await _repository.AddAsync(user);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _repository.GetAllAsync();
    }
}