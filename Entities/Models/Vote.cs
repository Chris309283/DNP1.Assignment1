namespace Entities.Models;

public class Vote
{
    public short Value { get; set; }
    public User? Voter { get; set; }
    public Vote(short value, User? voter)
    {
        Value = value;
        Voter = voter;
    }
    public Vote(short value)
    {
        Value = value;
    }

    private void Validate(short value)
    {
        
    }
}