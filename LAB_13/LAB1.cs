using System;

class Logger
{
    private static Logger instance;

    // Приватний конструктор
    private Logger() { }

    public static Logger Instance
    {
        get
        {
            if (instance == null)
                instance = new Logger();
            return instance;
        }
    }

    public void Log(string message)
    {
        Console.WriteLine("[LOG]: " + message);
    }
}

class Program
{
    static void Main()
    {
        Logger logger1 = Logger.Instance;
        Logger logger2 = Logger.Instance;

        logger1.Log("Початок роботи програми");
        logger2.Log("Логування з другого посилання");

        Console.WriteLine(
            "Один і той самий екземпляр? " + (logger1 == logger2)
        );
    }
}
