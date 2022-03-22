using BlazorUI.Services;
using Entities.Models;

namespace BlazorUI.Impls;

public class InMemoryUserService : IUserService
{
    public async Task<User?> GetUserAsync(string username)
    {
        User? find = users.Find(user => user.UserName.Equals(username));
        return find;
    }

    private List<User> users = new()
    {
        new User("Test", "Test123")
    };
}