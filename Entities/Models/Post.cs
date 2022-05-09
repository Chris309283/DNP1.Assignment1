using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Post
{
    [Key]
    public string PostId { get; set; }
    public string Header { get; set; }
    public string Body { get; set; }
    public ICollection<Vote> Votes { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public User WrittenBy { get; set; }
    public int GetVoteValue()
    {
        int value = 0;
        foreach (var vote in Votes)
        {
            value += vote.Value;
        }
        return value;
    }

    public override string ToString()
    {
        return PostId;
    }
}