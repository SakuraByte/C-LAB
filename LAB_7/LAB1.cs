using System;
using System.Collections.Generic;

// --- Власні винятки ---
class KilkistException : Exception
{
    public KilkistException(string message) : base(message) { }
}

class SmugaRozgonuException : Exception
{
    public SmugaRozgonuException(double length)
        : base($"Неможливо створити літак - вказана неправильна довжина смуги розгону: {length}")
    { }
}

// --- Клас Пасажир ---
class Passenger
{
    public string FullName { get; set; }
    public int SeatNumber { get; set; }

    public Passenger(string fullName, int seatNumber)
    {
        FullName = fullName;
        SeatNumber = seatNumber;
    }

    public override string ToString() => $"Пасажир: {FullName}, місце №{SeatNumber}";
}

// --- Базовий клас Літальний апарат ---
abstract class Aircraft
{
    public string Name { get; set; }
    public int MaxPassengers { get; set; }
    protected List<Passenger> passengers = new List<Passenger>();

    public Aircraft(string name, int maxPassengers)
    {
        Name = name;
        MaxPassengers = maxPassengers;
    }

    // Додати пасажира з перевіркою на перевищення максимальної кількості
    public void AddPassenger(Passenger p)
    {
        try
        {
            if (passengers.Count >= MaxPassengers)
                throw new KilkistException($"Перевищено максимальну кількість пасажирів ({MaxPassengers})");
            passengers.Add(p);
            Console.WriteLine($"Додано пасажира: {p.FullName}");
        }
        catch (KilkistException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }

    public abstract void TakeOff(); // Зліт
}

// --- Клас Літак ---
class Airplane : Aircraft
{
    public double RunwayLength { get; set; }

    public Airplane(string name, int maxPassengers, double runwayLength) : base(name, maxPassengers)
    {
        if (runwayLength <= 0)
            throw new SmugaRozgonuException(runwayLength);

        RunwayLength = runwayLength;
    }

    public override void TakeOff()
    {
        try
        {
            if (RunwayLength < 500) // приклад мінімальної довжини смуги
                throw new Exception($"Смуга розгону надто коротка: {RunwayLength} м");
            Console.WriteLine($"Літак {Name} успішно злетів зі смуги {RunwayLength} м!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка зльоту літака {Name}: {ex.Message}");
        }
    }
}

// --- Клас Гелікоптер ---
class Helicopter : Aircraft
{
    public Helicopter(string name, int maxPassengers) : base(name, maxPassengers) { }

    public override void TakeOff()
    {
        try
        {
            Console.WriteLine($"Гелікоптер {Name} злетів!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка зльоту гелікоптера {Name}: {ex.Message}");
        }
    }
}

// --- Клас Аеропорт ---
class Airport
{
    public string Name { get; set; }

    public Airport(string name) => Name = name;

    public void ShowInfo()
    {
        Console.WriteLine($"Аеропорт: {Name}");
    }
}

// --- Main ---
class Program
{
    static void Main()
    {
        // Створення аеропорту
        Airport airport = new Airport("Бориспіль");
        airport.ShowInfo();

        // --- Тестування літака ---
        try
        {
            Airplane airplane = new Airplane("Boeing-737", 2, -100); // негативна довжина смуги
        }
        catch (SmugaRozgonuException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Повторна спроба створити літак з коректною смугою...");
            Airplane airplane = new Airplane("Boeing-737", 2, 1500);

            // Додавання пасажирів
            airplane.AddPassenger(new Passenger("Іван Іваненко", 1));
            airplane.AddPassenger(new Passenger("Петро Петренко", 2));
            airplane.AddPassenger(new Passenger("Марія Марченко", 3)); // перевищення кількості

            // Зліт літака
            airplane.TakeOff();
        }

        // --- Тестування гелікоптера ---
        Helicopter helicopter = new Helicopter("Мі-8", 3);
        helicopter.AddPassenger(new Passenger("Олег Олегенко", 1));
        helicopter.TakeOff();
    }
}
