using Contracts.Services;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PostsController : ControllerBase
{
    private IPostService postService;

    public PostsController(IPostService postService)
    {
        this.postService = postService;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<Post>>> GetAllPosts()
    {
        try
        {
            ICollection<Post> posts = await postService.GetPostsAsync();
            return Ok(posts);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("{postId}")]
    public async Task<ActionResult<Post>> GetPostById([FromRoute] string postId)
    {
        try
        {
            Post post = await postService.GetPostAsync(postId);
            return Ok(post);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Post>> AddPostAsync([FromBody] Post post)
    {
        try
        {
            Post added = await postService.AddPostAsync(post);
            return Created($"/Posts/{added.PostId}", added);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    [Route("comment/{postId}")]
    public async Task<ActionResult> AddComment([FromBody] Comment comment,[FromRoute] string postId)
    {
        try
        {
            await postService.AddComment(comment, postId);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    [Route("vote/{postId}")]
    public async Task<ActionResult> AddVote([FromBody] Vote vote,[FromRoute] string postId)
    {
        try
        {
            await postService.AddVote(vote, postId);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
}