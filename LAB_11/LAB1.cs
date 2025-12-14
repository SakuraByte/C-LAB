using System;

class Program
{
    static void Main()
    {
        string input = "1010010110";
        Console.WriteLine("Початковий рядок: " + input);

        Console.Write("Введіть позицію, з якої почати заміну (0-based): ");
        int startPos = int.Parse(Console.ReadLine());

        char[] chars = input.ToCharArray();
        for (int i = startPos; i < chars.Length; i++)
        {
            if (chars[i] == '0') chars[i] = '1';
            else if (chars[i] == '1') chars[i] = '0';
        }

        string output = new string(chars);
        Console.WriteLine("Рядок після заміни: " + output);
    }
}
