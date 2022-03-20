﻿namespace Entities.Models;

public class Comment
{
    public string Body { get; set; }
    public Comment ParentComment { get; set; }
    public ICollection<Vote> Type { get; set; }
    public User WrittenBy { get; set; }
}