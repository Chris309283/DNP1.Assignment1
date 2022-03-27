using Application.Repositories;
using Entities.Models;
using JsonDataAccess.Context;

namespace JsonDataAccess.RepoImpls;

public class JsonPostRepo : IPostRepo
{
    private JsonContext jsonContext;

    public JsonPostRepo(JsonContext jsonContext)
    {
        this.jsonContext = jsonContext;
    }

    public async Task<ICollection<Post>?> GetPostsAsync()
    {
        return await Task.FromResult(jsonContext.Forum.Posts);
    }

    public Task<Post?> GetPostAsync(string? postId)
    {
        return Task.FromResult(jsonContext.Forum.Posts.FirstOrDefault(x =>postId != null && postId.Equals(x.PostId)));
    }

    public async Task<Post> AddPostAsync(Post post)
    {
        jsonContext.Forum.Posts.Add(post);
        await jsonContext.SaveChangesAsync();
        return post;
    }

    public async void AddComment(Comment comment, string? postId)
    {
        var post = await GetPostAsync(postId);
        post?.Comments.Add(comment);
        await jsonContext.SaveChangesAsync();
    }

    public async void AddVote(Vote vote, string? postId)
    {
        var post = GetPostAsync(postId).Result;
        post?.Votes.Add(vote);
        await jsonContext.SaveChangesAsync();
    }
}