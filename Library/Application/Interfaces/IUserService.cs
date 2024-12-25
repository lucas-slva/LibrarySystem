using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface IUserService
{
    Task AddUserAsync(User user);
    Task<IEnumerable<User>> GetAllUsersAsync();
}