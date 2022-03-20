namespace Entities.Models;

public class Post
{
    public string Header { get; set; }
    public string Body { get; set; }
    public ICollection<Vote> Votes { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public User WrittenBy { get; set; }

    public Post(string header, string body, User writtenBy)
    {
        Header = header;
        Body = body;
        WrittenBy = writtenBy;
    }
}