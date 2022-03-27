namespace Entities.Models;

public class Comment
{
    public string? Body { get; set; }
    public ICollection<Vote> Votes { get; set; }
    public User? WrittenBy { get; set; }

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