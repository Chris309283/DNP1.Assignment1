using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Comment
{
    public string? Body { get; set; }
    public ICollection<Vote> Votes { get; set; }

    public User? WrittenBy { get; set; }

    public Post Post { get; set; }

    [ForeignKey(nameof(WrittenBy))] public string UserName { get; set; }
    [ForeignKey(nameof(Post))] public string PostId { get; set; }

    public Comment(string? body, User? writtenBy)
    {
        Body = body;
        WrittenBy = writtenBy;
        Votes = new List<Vote>();
    }

    public Comment()
    {
        Votes = new List<Vote>();
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