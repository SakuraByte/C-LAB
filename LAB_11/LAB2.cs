using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть дату (дд.мм.рррр): ");
        string input = Console.ReadLine();
        DateTime targetDate;

        if (DateTime.TryParseExact(input, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out targetDate))
        {
            DateTime today = DateTime.Today;
            TimeSpan diff = targetDate - today;

            if (diff.TotalDays < 0)
                Console.WriteLine("Ця дата вже минула.");
            else
                Console.WriteLine($"Кількість днів до дати: {diff.Days}");
        }
        else
        {
            Console.WriteLine("Некоректний формат дати.");
        }
    }
}
