﻿namespace Entities.Models;

public class User
{
    public User(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }

    public User()
    {
    }

    public string UserName { get; set; }
    public string Password { get; set; }
}