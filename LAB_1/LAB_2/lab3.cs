using System;

class Program
{
    static void Main()
    {
        double average = MathOps.Average(3, 6, 9);
        Console.WriteLine("Середнє арифметичне: " + average);
    }
}

class MathOps
{
    public static double Average(int a, int b, int c)
    {
        return (a + b + c) / 3.0;
    }
}
