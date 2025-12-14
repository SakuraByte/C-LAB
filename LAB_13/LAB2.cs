using System;

abstract class Transport
{
    public int Speed { get; protected set; }
    public abstract void Move();
}

class Car : Transport
{
    public Car(int speed)
    {
        Speed = speed;
    }

    public override void Move()
    {
        Console.WriteLine($"Автомобіль рухається зі швидкістю {Speed} км/год");
    }
}

class Bike : Transport
{
    public Bike(int speed)
    {
        Speed = speed;
    }

    public override void Move()
    {
        Console.WriteLine($"Велосипед рухається зі швидкістю {Speed} км/год");
    }
}

class TransportFactory
{
    public static Transport Create(string type, int speed)
    {
        if (type == "car")
            return new Car(speed);
        if (type == "bike")
            return new Bike(speed);

        throw new Exception("Невідомий тип транспорту");
    }
}

class Program
{
    static void Main()
    {
        Transport car = TransportFactory.Create("car", 110);
        Transport bike = TransportFactory.Create("bike", 20);

        car.Move();
        bike.Move();
    }
}
