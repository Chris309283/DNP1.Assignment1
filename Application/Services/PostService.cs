using Application.Repositories;
using Contracts.Services;
using Entities.Models;

namespace Application.Services;

public class PostService : IPostService
{
    private IPostRepo postRepo;

    public PostService(IPostRepo postRepo)
    {
        this.postRepo = postRepo;
    }

    public async Task<ICollection<Post>> GetPostsAsync()
    {
       return await postRepo.GetPostsAsync();
    }

    public async Task<Post?> GetPostAsync(string? id)
    {
        return await postRepo.GetPostAsync(id);
    }

    public async Task<Post> AddPostAsync(Post post)
    {
        return await postRepo.AddPostAsync(post);
    }

    public async Task<Post?> AddComment(Comment comment, string? postId)
    {
        return await postRepo.AddComment(comment, postId);
    }

    public async Task<Post?> AddVote(Vote vote, string postId)
    {
        return await postRepo.AddVote(vote, postId);
    }
}