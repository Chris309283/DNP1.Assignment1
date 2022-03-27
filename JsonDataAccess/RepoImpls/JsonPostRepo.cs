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

    public Task<ICollection<Post>> GetPostsAsync()
    {
        return Task.FromResult(jsonContext.Forum.Posts);
    }

    public Task<Post?> GetPostAsync(string? postId)
    {
        return Task.FromResult(jsonContext.Forum.Posts.FirstOrDefault(x => postId != null && postId.Equals(x.PostId)));
    }

    public async Task<Post> AddPostAsync(Post post)
    {
        jsonContext.Forum.Posts.Add(post);
        await jsonContext.SaveChangesAsync();
        return post;
    }

    public async Task<Post?> AddComment(Comment comment, string? postId)
    {
        Post? post = await GetPostAsync(postId);
        post?.Comments.Add(comment);
        await jsonContext.SaveChangesAsync();
        return post;
    }

    public async Task<Post?> AddVote(Vote vote, string postId)
    {
        Post? oldPost = GetPostAsync(postId).Result;
        if (oldPost != null)
        {
            oldPost.Votes.Add(vote);
            await jsonContext.SaveChangesAsync(); 
        }
        return oldPost;
    }
}