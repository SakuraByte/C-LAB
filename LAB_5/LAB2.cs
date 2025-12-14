using System;

interface ISaveable
{
    void Save();
}

class File : ISaveable
{
    public string FileName { get; set; }
    public File(string fileName) => FileName = fileName;

    void ISaveable.Save()
    {
        Console.WriteLine($"Файл {FileName} збережено через інтерфейс.");
    }
}

class Program
{
    static void Main()
    {
        File file = new File("document.txt");

        ISaveable saveable = file;
        saveable.Save();
    }
}
