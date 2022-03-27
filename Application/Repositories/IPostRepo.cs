using Entities.Models;

namespace Application.Repositories;

public interface IPostRepo
{
    Task<ICollection<Post>?> GetPostsAsync();
    Task<Post?> GetPostAsync(string? id);
    Task<Post> AddPostAsync(Post post);
    void AddComment(Comment comment, string? postId);
    void AddVote(Vote vote, string? postId);
}