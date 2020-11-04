using System;
using System.Collections.Generic;

public class UserManager
{
    public Dictionary<string, User> Users = new Dictionary<string, User>();

    public User AddUser(string username)
    {
        if (Users.ContainsKey(username))
        {
            return Users[username];
        }
        var newuser = new User { UserName = username };
        Users.Add(username, newuser);

        return newuser;
        // Console.WriteLine("Users ----------");
        // foreach (var user in Users)
        // {
        //     Console.WriteLine(user.Value.UserName);
        // }
        // Console.WriteLine("----------");
    }

    public void SendMessage(string message)
    {
        foreach (var user in Users)
        {
            Console.WriteLine(user.Value.UserName);
            user.Value.SendMessage(message);
        }
    }

}