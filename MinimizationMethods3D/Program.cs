using System;

class Program
{
    static void Main()
    {
        double epsilon = 1e-6; // Погрешность ответа
        double stepSize = 0.1; // Шаг обучения
        int maxIterations = 10000; // Максимальное число итераций

        // Начальные значения переменных
        double x = 1.0;
        double y = 2.0;

        int iteration = 0;
        double gradient1, gradient2;

        do
        {
            // Вычисляем градиент функции в текущей точке
            gradient1 = GradientFunctionPartialX1(x, y);
            gradient2 = GradientFunctionPartialX2(x, y);

            // Обновляем переменные с постоянным шагом
            x -= stepSize * gradient1;
            y -= stepSize * gradient2;

            iteration++;

            // Выход из цикла, если достигнута погрешность или максимальное число итераций
        } while (iteration < maxIterations && Math.Sqrt(gradient1 * gradient1 + gradient2 * gradient2) > epsilon);

        // Вычисляем значение функции в минимуме
        double minValue = ObjectiveFunction(x, y);

        // Выводим результаты
        Console.WriteLine("Минимум функции: " + minValue);
        Console.WriteLine("Значения переменных, приводящие к минимуму:");
        Console.WriteLine("x = " + x);
        Console.WriteLine("y = " + y);
        Console.WriteLine("Число итераций: " + iteration);

    }

    // Ваша функция
    static double ObjectiveFunction(double x1, double x2)
    {
        return Math.Sqrt(x1 * x1 + x2 * x2 + 1) + x1 / 2 - x2 / 2;
    }

    // Частная производная функции по x
    static double GradientFunctionPartialX1(double x1, double x2)
    {
        return x1 / Math.Sqrt(x1 * x1 + x2 * x2 + 1) + 0.5;
    }

    // Частная производная функции по y
    static double GradientFunctionPartialX2(double x1, double x2)
    {
        return x2 / Math.Sqrt(x1 * x1 + x2 * x2 + 1) - 0.5;
    }
}
