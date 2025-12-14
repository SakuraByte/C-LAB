using System;

abstract class Figure
{
    public abstract double Perimeter();
}

class Rectangle : Figure
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double Perimeter()
    {
        return 2 * (Width + Height);
    }
}

class Circle : Figure
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double Perimeter()
    {
        return 2 * Math.PI * Radius;
    }
}

class Program
{
    static void Main()
    {
        Rectangle rect = new Rectangle(5, 3);
        Circle circle = new Circle(4);

        Console.WriteLine("Периметр прямокутника: " + rect.Perimeter());
        Console.WriteLine("Периметр кола: " + circle.Perimeter());
    }
}
