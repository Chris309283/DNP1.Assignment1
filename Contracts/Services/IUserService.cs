using Entities.Models;

namespace Contracts.Services;

public interface IUserService
{
    Task<ICollection<User>> GetAllUsersAsync();
    public Task<User?> GetUserAsync(string? username);
    Task<User> AddUserAsync(User user);
    Task Update(User user);
}