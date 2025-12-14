using System;

class Box<T> : ICloneable
{
    public T Value { get; set; }

    public Box(T value) => Value = value;

    public object Clone()
    {
        return new Box<T>(Value);
    }

    public override string ToString() => $"Box: {Value}";
}

class Program
{
    static void Main()
    {
        Box<int> box1 = new Box<int>(42);
        Box<int> box2 = (Box<int>)box1.Clone();

        Console.WriteLine(box1);
        Console.WriteLine(box2);
    }
}
