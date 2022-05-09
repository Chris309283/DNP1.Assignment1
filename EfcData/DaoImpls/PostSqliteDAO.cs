using Contracts.Services;
using Entities.Models;

namespace EfcData.DaoImpls;

public class PostSqliteDAO : IPostService
{
    public Task<ICollection<Post>?> GetPostsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Post?> GetPostAsync(string? id)
    {
        throw new NotImplementedException();
    }

    public Task<Post> AddPostAsync(Post post)
    {
        throw new NotImplementedException();
    }

    public Task AddComment(Comment comment, string? postId)
    {
        throw new NotImplementedException();
    }

    public Task AddVote(Vote vote, string? postId)
    {
        throw new NotImplementedException();
    }
}