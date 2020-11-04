using System;
using System.Collections.Generic;

public class UserManager
{
    private readonly object Mutex = new object();
    public Dictionary<string, User> Users = new Dictionary<string, User>();

    public User AddUser(string username)
    {
        lock (Mutex)
        {
            if (Users.ContainsKey(username))
            {
                return Users[username];
            }
            var newuser = new User { UserName = username };
            Users.Add(username, newuser);
            return newuser;
        }
        // Console.WriteLine("Users ----------");
        // foreach (var user in Users)
        // {
        //     Console.WriteLine(user.Value.UserName);
        // }
        // Console.WriteLine("----------");
    }

    public void SendMessageToAll(string message)
    {
        lock (Mutex)
        {
            foreach (var user in Users)
            {
                Console.WriteLine(user.Value.UserName);
                user.Value.SendMessage(message);
            }
        }
    }

    public void SendMessageToUser(string message, string username)
    {
        lock (Mutex)
        {
            if (!Users.ContainsKey(username)) return;

            Users[username].SendMessage(message);
        }
    }

}