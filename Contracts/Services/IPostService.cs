using Entities.Models;

namespace Contracts.Services;

public interface IPostService
{
    Task<ICollection<Post>?> GetPostsAsync();
    Task<Post?> GetPostAsync(string? id);
    Task<Post> AddPostAsync(Post post);
    void AddComment(Comment comment, string? postId);
    void AddVote(Vote vote, string? postId);
}