using Application.Repositories;
using Entities.Models;
using JsonDataAccess.Context;

namespace JsonDataAccess.RepoImpls;

public class JsonUserRepo : IUserRepo
{
    private JsonContext jsonContext;

    public JsonUserRepo(JsonContext jsonContext)
    {
        this.jsonContext = jsonContext;
    }

    public Task<ICollection<User>> GetAllUsersAsync()
    {
        return Task.FromResult(jsonContext.Forum.Users);
    }

    public Task<User?> GetUserAsync(string username)
    {
        User? user = jsonContext.Forum.Users.FirstOrDefault(x => username.Equals(x.UserName));
        return Task.FromResult(user);
    }

    public async Task<User> AddUserAsync(User user)
    {
        if (await UsernameTaken(user.UserName))
        {
            throw new Exception("Username not available");
        }

        jsonContext.Forum.Users.Add(user);
        await jsonContext.SaveChangesAsync();
        return user;
    }

    public async Task Update(User user)
    {
        User? oldUser = GetUserAsync(user.UserName).Result;
        if (oldUser != null)
        {
            oldUser.UserName = user.UserName;
            oldUser.Password = user.Password;
        }

        await jsonContext.SaveChangesAsync();
    }

    private Task<bool> UsernameTaken(string username)
    {
        return Task.FromResult(jsonContext.Forum.Users.Any(u => username.Equals(u.UserName)));
    }
}