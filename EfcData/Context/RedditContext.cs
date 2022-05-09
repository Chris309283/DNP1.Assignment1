using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EfcData.Context;

public class RedditContext : DbContext
{
    public DbSet<Comment> Comments {get; set;}
    public DbSet<Post> Posts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Vote> Votes { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source = Reddit.db");
    }
}