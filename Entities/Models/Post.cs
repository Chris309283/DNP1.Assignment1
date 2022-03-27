namespace Entities.Models;

public class Post
{
    public string PostId { get; }
    public string? Header { get; set; }
    public string? Body { get; set; }
    public ICollection<Vote> Votes { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public User? WrittenBy { get; set; }

    public Post(string? header, string? body, User? writtenBy)
    {
        Header = header;
        Body = body;
        WrittenBy = writtenBy;
        PostId = Guid.NewGuid().ToString("N");
        Votes = new List<Vote>();
        Comments = new List<Comment>();
    }
    public Post()
    {
        PostId = Guid.NewGuid().ToString("N");
        Votes = new List<Vote>();
        Comments = new List<Comment>();
    }

    public int GetVoteValue()
    {
        int value = 0;
        foreach (var vote in Votes)
        {
            value += vote.Value;
        }

        return value;
    }
}