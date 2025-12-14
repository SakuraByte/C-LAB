using System;

class Program
{
    static void Main()
    {
        Book book = new Book();
        book.SetTitle("1984");
        book.SetAuthor("George Orwell");
        book.SetYear(1949);

        Console.WriteLine("Назва: " + book.GetTitle());
        Console.WriteLine("Автор: " + book.GetAuthor());
        Console.WriteLine("Рік: " + book.GetYear());
    }
}

class Book
{
    private string title;
    private string author;
    private int year;

    public void SetTitle(string title)
    {
        this.title = title;
    }

    public string GetTitle()
    {
        return title;
    }

    public void SetAuthor(string author)
    {
        this.author = author;
    }

    public string GetAuthor()
    {
        return author;
    }

    public void SetYear(int year)
    {
        this.year = year;
    }

    public int GetYear()
    {
        return year;
    }
}
