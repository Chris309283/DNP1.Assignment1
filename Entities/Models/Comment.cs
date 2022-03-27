namespace Entities.Models;

public class Comment
{
    public string? Body { get; set; }
    public Comment? ParentComment { get; set; }
    public ICollection<Vote> Votes { get; set; }
    public User? WrittenBy { get; set; }

    public Comment()
    {
        Votes = new List<Vote>();
    }

    public Comment(string? body, Comment? parentComment, User? writtenBy)
    {
        Body = body;
        ParentComment = parentComment;
        WrittenBy = writtenBy;
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

