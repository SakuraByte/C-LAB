using System;
using System.Collections.Generic;

class SetChar
{
    private HashSet<char> elements;

    public SetChar(IEnumerable<char> initialElements = null)
    {
        elements = initialElements != null ? new HashSet<char>(initialElements) : new HashSet<char>();
    }

    public void Add(char c) => elements.Add(c);

    public void Display()
    {
        Console.Write("{ ");
        foreach (var c in elements)
            Console.Write(c + " ");
        Console.WriteLine("}");
    }

    public static SetChar operator -(SetChar set, char c)
    {
        var newSet = new SetChar(set.elements);
        newSet.elements.Remove(c);
        return newSet;
    }

    public static bool operator >(SetChar set1, SetChar set2)
    {
        return set2.elements.IsSubsetOf(set1.elements);
    }

    public static bool operator <(SetChar set1, SetChar set2)
    {
        return set1.elements.IsSubsetOf(set2.elements);
    }

    public static bool operator !=(SetChar set1, SetChar set2)
    {
        return !set1.elements.SetEquals(set2.elements);
    }

    public static bool operator ==(SetChar set1, SetChar set2)
    {
        return set1.elements.SetEquals(set2.elements);
    }

    public override bool Equals(object obj)
    {
        if (obj is SetChar other)
            return this.elements.SetEquals(other.elements);
        return false;
    }

    public override int GetHashCode()
    {
        int hash = 17;
        foreach (var c in elements)
            hash = hash * 31 + c.GetHashCode();
        return hash;
    }
}

class Program
{
    static void Main()
    {
        SetChar setA = new SetChar(new char[] { 'a', 'b', 'c' });
        SetChar setB = new SetChar(new char[] { 'a', 'b' });

        Console.WriteLine("Множина A:");
        setA.Display();

        Console.WriteLine("Множина B:");
        setB.Display();

        SetChar setC = setA - 'b';
        Console.WriteLine("Множина A після видалення 'b':");
        setC.Display();

        Console.WriteLine($"B є підмножиною A? {setA > setB}");
        Console.WriteLine($"A != B? {setA != setB}");
    }
}
