using System;

abstract class TBody
{
    public abstract double SurfaceArea();
    public abstract double Volume();
    public virtual void Display()
    {
        Console.WriteLine($"Площа поверхні: {SurfaceArea():F2}, Об'єм: {Volume():F2}");
    }
}

class TParallelepiped : TBody
{
    public double Length { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }

    public TParallelepiped(double length, double width, double height)
    {
        Length = length; Width = width; Height = height;
    }

    public override double SurfaceArea() => 2 * (Length * Width + Length * Height + Width * Height);
    public override double Volume() => Length * Width * Height;

    public override string ToString() => $"Паралелепіпед (L={Length}, W={Width}, H={Height})";
}

class TBall : TBody
{
    public double Radius { get; set; }
    public TBall(double radius) => Radius = radius;

    public override double SurfaceArea() => 4 * Math.PI * Radius * Radius;
    public override double Volume() => (4.0 / 3) * Math.PI * Radius * Radius * Radius;

    public override string ToString() => $"Куля (R={Radius})";
}

class Program
{
    static void Main()
    {
        Random rand = new Random();
        int n = 5;
        TBody[] bodies = new TBody[n];
        double totalSurface = 0;

        for (int i = 0; i < n; i++)
        {
            if (rand.Next(2) == 0)
                bodies[i] = new TParallelepiped(rand.Next(1,10), rand.Next(1,10), rand.Next(1,10));
            else
                bodies[i] = new TBall(rand.Next(1,10));

            Console.WriteLine(bodies[i].ToString());
            bodies[i].Display();
            totalSurface += bodies[i].SurfaceArea();
        }

        Console.WriteLine($"\nСумарна площа поверхонь усіх тіл: {totalSurface:F2}");
    }
}
