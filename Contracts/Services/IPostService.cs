using Entities.Models;

namespace Contracts.Services;

public interface IPostService
{
    Task<ICollection<Post>> GetPostsAsync();
    Task<Post?> GetPostAsync(string? id);
    Task<Post> AddPostAsync(Post post);
    Task<Post?> AddComment(Comment comment, string? postId);
    Task<Post?> AddVote(Vote vote, string postId);
}