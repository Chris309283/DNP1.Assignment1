

namespace Entities.Models;

public class Vote
{
    public short Value { get; set; }
    
    public User Voter { get; set; }
    
    public Post Post { get; set;}
    
    public Comment Comment { get; set;}
    public Vote(short value, User voter)
    {
        Value = value;
        Voter = voter;
    }
}