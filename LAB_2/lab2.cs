using System;

class Program
{
    static void Main()
    {
        MathOperations math = new MathOperations();

        Console.WriteLine(math.Add(2, 3));
        Console.WriteLine(math.Add(1, 2, 3));
        Console.WriteLine(math.Add(1, 2, 3, 4));
    }
}

class MathOperations
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }

    public int Add(int a, int b, int c, int d)
    {
        return a + b + c + d;
    }
}
