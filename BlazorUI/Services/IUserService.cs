using Entities.Models;

namespace BlazorUI.Services;

public interface IUserService
{
    public Task<User?> GetUserAsync(string username);
}