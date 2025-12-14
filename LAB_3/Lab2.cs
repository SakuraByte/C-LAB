using System;

class Appliance
{
    public virtual void Operate()
    {
        Console.WriteLine("Пристрій працює");
    }
}

class WashingMachine : Appliance
{
    public override void Operate()
    {
        Console.WriteLine("Пральна машина переться");
    }
}

class Refrigerator : Appliance
{
    public override void Operate()
    {
        Console.WriteLine("Холодильник охолоджує продукти");
    }
}

class Program
{
    static void Main()
    {
        Appliance appliance = new Appliance();
        WashingMachine wm = new WashingMachine();
        Refrigerator fridge = new Refrigerator();

        appliance.Operate();
        wm.Operate();
        fridge.Operate();
    }
}
