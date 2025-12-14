using System;

class Wing
{
    public double Span { get; set; }
    public Wing(double span) => Span = span;
    public override string ToString() => $"Крила: розмах {Span} м";
    public override bool Equals(object obj) => obj is Wing w && w.Span == Span;
    public override int GetHashCode() => Span.GetHashCode();
}

class Chassis
{
    public int Wheels { get; set; }
    public Chassis(int wheels) => Wheels = wheels;
    public override string ToString() => $"Шасі: {Wheels} коліс";
    public override bool Equals(object obj) => obj is Chassis c && c.Wheels == Wheels;
    public override int GetHashCode() => Wheels.GetHashCode();
}

class Engine
{
    public int Power { get; set; }
    public Engine(int power) => Power = power;
    public override string ToString() => $"Двигун: {Power} к.с.";
    public override bool Equals(object obj) => obj is Engine e && e.Power == Power;
    public override int GetHashCode() => Power.GetHashCode();
}

class Airplane
{
    public Wing Wing { get; set; }
    public Chassis Chassis { get; set; }
    public Engine Engine { get; set; }
    public string Route { get; set; }

    public Airplane(Wing wing, Chassis chassis, Engine engine)
    {
        Wing = wing;
        Chassis = chassis;
        Engine = engine;
        Route = "Не задано";
    }

    public void Fly() => Console.WriteLine("Літак летить по маршруту: " + Route);
    public void SetRoute(string route) => Route = route;
    public void ShowRoute() => Console.WriteLine("Маршрут літака: " + Route);

    public override string ToString() =>
        $"Літак:\n{Wing}\n{Chassis}\n{Engine}\nМаршрут: {Route}";

    public override bool Equals(object obj) =>
        obj is Airplane a && a.Wing.Equals(Wing) && a.Chassis.Equals(Chassis) && a.Engine.Equals(Engine) && a.Route == Route;

    public override int GetHashCode() => HashCode.Combine(Wing, Chassis, Engine, Route);
}

class Program
{
    static void Main()
    {
        Wing wing = new Wing(35);
        Chassis chassis = new Chassis(6);
        Engine engine = new Engine(5000);

        Airplane airplane = new Airplane(wing, chassis, engine);
        airplane.SetRoute("Київ → Лондон");
        airplane.Fly();
        airplane.ShowRoute();

        Console.WriteLine(airplane.ToString());
    }
}
