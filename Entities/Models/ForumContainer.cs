namespace Entities.Models;

public class ForumContainer
{
    // Add e.g. ICollection<Post> or ICollection<SubForum> or similar.
    public ICollection<User> Users { get; set; }
    public ICollection<Post> Posts { get; set; }
    public ICollection<SubForum> SubForums { get; set; }
}