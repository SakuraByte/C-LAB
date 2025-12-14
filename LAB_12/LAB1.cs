using System;
using System.Xml;

class Program
{
    static void Main()
    {
        // ===== Створення XML-документа =====
        XmlDocument doc = new XmlDocument();

        XmlElement root = doc.CreateElement("students");
        doc.AppendChild(root);

        string[] students =
        {
            "Ivan Petrenko", "Oleh Ivanov", "Anna Kovalenko",
            "Maria Shevchenko", "Dmytro Bondar", "Olena Tkachenko",
            "Andrii Melnyk", "Iryna Koval", "Serhii Moroz", "Kateryna Lysenko"
        };

        string[] groups = { "CS-21", "CS-22", "SE-21" };
        double[] grades = { 4.5, 3.8, 4.2, 4.9, 3.6, 4.0, 4.7, 3.9, 4.1, 4.8 };

        for (int i = 0; i < students.Length; i++)
        {
            XmlElement student = doc.CreateElement("student");

            XmlElement name = doc.CreateElement("name");
            name.InnerText = students[i];

            XmlElement group = doc.CreateElement("group");
            group.InnerText = groups[i % groups.Length];

            XmlElement average = doc.CreateElement("average");
            average.InnerText = grades[i].ToString();

            student.AppendChild(name);
            student.AppendChild(group);
            student.AppendChild(average);

            root.AppendChild(student);
        }

        doc.Save("students.xml");
        Console.WriteLine("Файл students.xml успішно створено.\n");

        // ===== XPath-запит =====
        Console.Write("Введіть назву групи: ");
        string searchGroup = Console.ReadLine();

        XmlNodeList result =
            doc.SelectNodes($"//student[group='{searchGroup}']");

        Console.WriteLine($"\nСтуденти групи {searchGroup}:");

        if (result.Count == 0)
        {
            Console.WriteLine("Студентів не знайдено.");
        }
        else
        {
            foreach (XmlNode node in result)
            {
                string fullName = node["name"].InnerText;
                string surname = fullName.Split(' ')[1];
                Console.WriteLine(surname);
            }
        }
    }
}
