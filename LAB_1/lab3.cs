using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть кількість елементів масиву: ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"arr[{i}] = ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Парні числа в масиві:");

        for (int i = 0; i < n; i++)
        {
            if (arr[i] % 2 == 0)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
