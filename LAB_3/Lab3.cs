using System;

class Program
{
    // Узагальнений метод Swap<T>
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    static void Main()
    {
        int x = 5, y = 10;
        Console.WriteLine($"До Swap: x = {x}, y = {y}");
        Swap(ref x, ref y);
        Console.WriteLine($"Після Swap: x = {x}, y = {y}");

        string str1 = "Hello", str2 = "World";
        Console.WriteLine($"До Swap: str1 = {str1}, str2 = {str2}");
        Swap(ref str1, ref str2);
        Console.WriteLine($"Після Swap: str1 = {str1}, str2 = {str2}");
    }
}
