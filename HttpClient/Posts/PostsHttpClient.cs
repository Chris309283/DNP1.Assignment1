using System.Text;
using System.Text.Json;
using Contracts.Services;
using Entities.Models;

namespace HttpClient.Posts;

public class PostsHttpClient : IPostService
{
    public async Task<ICollection<Post>?> GetPostsAsync()
    {
        using System.Net.Http.HttpClient client = new();
        Console.WriteLine("here1");
        HttpResponseMessage response = await client.GetAsync("https://localhost:7204/posts");
        Console.WriteLine("here2");
        string content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }

        ICollection<Post> posts = JsonSerializer.Deserialize<ICollection<Post>>(content,
            new JsonSerializerOptions {PropertyNameCaseInsensitive = true})!;
        foreach (var post in posts)
        {
            Console.WriteLine(post.WrittenBy);
        }
        
        return posts;
    }

    public async Task<Post?> GetPostAsync(string? id)
    {
        using System.Net.Http.HttpClient client = new();
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7204/posts/{id}");
        string content = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }

        var post = JsonSerializer.Deserialize<Post>(content,
            new JsonSerializerOptions {PropertyNameCaseInsensitive = true})!;

        return post;
    }

    public async Task<Post> AddPostAsync(Post post)
    {
        using System.Net.Http.HttpClient client = new();
        string postAsJson = JsonSerializer.Serialize(post);
        StringContent content = new(postAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync("https://localhost:7204/posts", content);
        string responseContent = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }

        var returned = JsonSerializer.Deserialize<Post>(responseContent,
            new JsonSerializerOptions {PropertyNameCaseInsensitive = true})!;

        return returned;
    }

    public async Task AddComment(Comment comment, string? postId)
    {
        using System.Net.Http.HttpClient client = new();
        string postAsJson = JsonSerializer.Serialize(comment);
        StringContent content = new(postAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync($"https://localhost:7204/posts/comment/{postId}", content);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }
    }

    public async Task AddVote(Vote vote, string? postId)
    {
        using System.Net.Http.HttpClient client = new();
        string postAsJson = JsonSerializer.Serialize(vote);
        StringContent content = new(postAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync($"https://localhost:7204/posts/vote/{postId}", content);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }
    }
}