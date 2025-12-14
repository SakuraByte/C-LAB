using System;

// Делегат для обчислення значення функції
public delegate double FuncDelegate(double x);

class RightRectangleIntegrator
{
    // Метод для обчислення інтегралу
    public static double Integrate(FuncDelegate f, double a, double b, int n)
    {
        double sum = 0;
        double dx = (b - a) / n;
        for (int i = 1; i <= n; i++) // праві прямокутники
        {
            sum += f(a + i * dx) * dx;
        }
        return sum;
    }
}

// Приклад використання
class Program
{
    // Функція для інтегрування
    public static double MyFunction(double x)
    {
        return x * x; // x^2
    }

    // Інший метод для демонстрації мультікастингу
    public static void PrintIntegral(double result)
    {
        Console.WriteLine($"Результат інтегрування: {result}");
    }

    static void Main()
    {
        // Використовуємо делегат
        FuncDelegate func = MyFunction;

        // Обчислюємо інтеграл від 0 до 2, n=1000
        double integral = RightRectangleIntegrator.Integrate(func, 0, 2, 1000);

        // Мультікастинг делегата
        Action<double> printActions = PrintIntegral;
        printActions += (res) => Console.WriteLine($"Підсумок: {res:F4}");
        printActions(integral);
    }
}
