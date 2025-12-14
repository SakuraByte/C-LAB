using System;
using System.IO;

class Program
{
    static void Main()
    {
        string disk = @"D:\";
        string labDir = Path.Combine(disk, "OOP_lab08");
        string groupDir = Path.Combine(labDir, "12345"); // замініть на номер своєї групи
        string surnameDir = Path.Combine(labDir, "Ivanov"); // замініть на своє прізвище
        string sourcesDir = Path.Combine(labDir, "Sources");
        string reportsDir = Path.Combine(labDir, "Reports");
        string textsDir = Path.Combine(labDir, "Texts");

        try
        {
            // 1. Створюємо основний каталог
            Directory.CreateDirectory(labDir);

            // 2. Створюємо підкаталоги
            Directory.CreateDirectory(groupDir);
            Directory.CreateDirectory(surnameDir);
            Directory.CreateDirectory(sourcesDir);
            Directory.CreateDirectory(reportsDir);
            Directory.CreateDirectory(textsDir);

            // 3. Копіюємо каталоги до каталогу прізвища
            CopyDirectory(sourcesDir, Path.Combine(surnameDir, "Sources"));
            CopyDirectory(reportsDir, Path.Combine(surnameDir, "Reports"));
            CopyDirectory(textsDir, Path.Combine(surnameDir, "Texts"));

            // 4. Переміщаємо каталог прізвища до каталогу групи
            string destSurnameDir = Path.Combine(groupDir, "Ivanov");
            if (Directory.Exists(destSurnameDir))
                Directory.Delete(destSurnameDir, true); // видаляємо старий, якщо існує
            Directory.Move(surnameDir, destSurnameDir);

            // 5. Створюємо dirinfo.txt в каталозі Texts
            string textsSubDir = Path.Combine(destSurnameDir, "Texts");
            string infoFile = Path.Combine(textsSubDir, "dirinfo.txt");
            using (StreamWriter sw = new StreamWriter(infoFile))
            {
                foreach (var file in Directory.GetFiles(textsSubDir))
                {
                    FileInfo fi = new FileInfo(file);
                    sw.WriteLine($"{fi.Name} | Розмір: {fi.Length} байт | Створено: {fi.CreationTime}");
                }
            }

            Console.WriteLine("Операції з файловою системою виконано успішно.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }

    static void CopyDirectory(string sourceDir, string destDir)
    {
        Directory.CreateDirectory(destDir);

        foreach (string file in Directory.GetFiles(sourceDir))
        {
            string destFile = Path.Combine(destDir, Path.GetFileName(file));
            File.Copy(file, destFile, true);
        }

        foreach (string dir in Directory.GetDirectories(sourceDir))
        {
            string destSubDir = Path.Combine(destDir, Path.GetFileName(dir));
            CopyDirectory(dir, destSubDir);
        }
    }
}
