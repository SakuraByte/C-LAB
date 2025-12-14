using System;
using System.Collections.Generic;
using System.Linq;

// Клас CollectionType з узагальненою колекцією List<T>
class CollectionType<T>
{
    public List<T> Items { get; set; }

    public CollectionType(List<T> items)
    {
        Items = items;
    }

    public int Size() => Items.Count;

    public override string ToString() => $"Collection: [{string.Join(", ", Items)}] (Size={Items.Count})";
}

class Program
{
    static void Main()
    {
        Random rand = new Random();

        // Створимо масив з 5 колекцій
        CollectionType<int>[] collections = new CollectionType<int>[5];

        for (int i = 0; i < collections.Length; i++)
        {
            int size = rand.Next(1, 10); // випадковий розмір колекції
            List<int> items = new List<int>();
            for (int j = 0; j < size; j++)
                items.Add(rand.Next(100)); // випадкові числа
            collections[i] = new CollectionType<int>(items);
        }

        // Виведемо всі колекції
        Console.WriteLine("Масив колекцій:");
        foreach (var c in collections)
            Console.WriteLine(c);

        // 1. Кількість колекцій заданого розміру
        Console.WriteLine("\nВведіть розмір для пошуку:");
        int targetSize = int.Parse(Console.ReadLine());

        int count = collections.Count(c => c.Size() == targetSize);
        Console.WriteLine($"Кількість колекцій розміром {targetSize}: {count}");

        // 2. Знайти максимальну та мінімальну колекцію за розміром
        var maxCollection = collections.OrderByDescending(c => c.Size()).First();
        var minCollection = collections.OrderBy(c => c.Size()).First();

        Console.WriteLine($"\nМаксимальна колекція: {maxCollection}");
        Console.WriteLine($"Мінімальна колекція: {minCollection}");
    }
}
