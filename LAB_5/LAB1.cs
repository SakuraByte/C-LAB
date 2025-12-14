using System;

interface ILoginable
{
    void Login();
}

class User : ILoginable
{
    public string Username { get; set; }
    public string Password { get; set; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public void Login()
    {
        Console.WriteLine($"Користувач {Username} увійшов у систему.");
    }
}

class Program
{
    static void Main()
    {
        ILoginable user = new User("Max", "12345");
        user.Login();
    }
}
