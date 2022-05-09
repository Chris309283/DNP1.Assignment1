using Contracts.Services;
using EfcData.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EfcData.DaoImpls;

public class UserSqliteDAO : IUserService
{
    private readonly RedditContext context;

    public UserSqliteDAO(RedditContext context)
    {
        this.context = context;
    }

    public async Task<ICollection<User>> GetAllUsersAsync()
    {
        var users = await context.Users.ToListAsync();
        return users;
    }

    public async Task<User> GetUserAsync(string? username)
    {
        var user = await context.Users.FirstAsync(a => a.UserName.Equals(username));
        return user;
    }

    public async Task<User> AddUserAsync(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return user;
    }

    public Task Update(User user)
    {
       // await context.Users.UpdateAsync(user);
       throw new NotImplementedException();
    }
}