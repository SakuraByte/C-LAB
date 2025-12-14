using System;
using System.Globalization;
using System.Linq;

class Program
{
    static void Main()
    {
        string input = "12.03.2023,25.05.2021,01.01.2024";
        Console.WriteLine("Вхідний рядок: " + input);

        string[] dateStrings = input.Split(',');
        DateTime[] dates = dateStrings
            .Select(d => DateTime.ParseExact(d.Trim(), "dd.MM.yyyy", CultureInfo.InvariantCulture))
            .ToArray();

        // a) Рік з найменшим номером
        int minYear = dates.Min(d => d.Year);
        Console.WriteLine("Рік з найменшим номером: " + minYear);

        // b) Всі весняні дати (березень, квітень, травень)
        Console.WriteLine("Весняні дати:");
        foreach (var d in dates)
        {
            if (d.Month >= 3 && d.Month <= 5)
                Console.WriteLine(d.ToString("dd.MM.yyyy"));
        }

        // c) Найпізніша дата
        DateTime latest = dates.Max();
        Console.WriteLine("Найпізніша дата: " + latest.ToString("dd.MM.yyyy"));
    }
}
