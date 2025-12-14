using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = @"D:\OOP_lab08\Texts\f.txt"; // шлях до файлу

        try
        {
            // Зчитування всіх чисел з файлу
            int[] numbers = File.ReadAllText(filePath)
                                .Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            // 1. Кількість парних чисел
            int evenCount = numbers.Count(n => n % 2 == 0);

            // 2. Кількість подвоєних парних чисел
            int doubleEvenCount = numbers.Count(n => n % 2 == 0 && n % 4 == 0);

            // 3. Кількість квадратів непарних чисел
            int squareOddCount = numbers.Count(n =>
            {
                if (n % 2 != 0)
                {
                    double sqrt = Math.Sqrt(n);
                    return sqrt == (int)sqrt;
                }
                return false;
            });

            Console.WriteLine($"Кількість парних чисел: {evenCount}");
            Console.WriteLine($"Кількість подвоєних парних чисел: {doubleEvenCount}");
            Console.WriteLine($"Кількість квадратів непарних чисел: {squareOddCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}
