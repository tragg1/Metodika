using System;

class Program
{
    // Задача 1: сумма большего и меньшего из 3 чисел
    static double SumMaxMin(double a, double b, double c)
    {
        double max = Math.Max(a, Math.Max(b, c));
        double min = Math.Min(a, Math.Min(b, c));
        return max + min;
    }

    // Задача 2: число на [2, n] с максимальной суммой делителей
    static int SumDivisors(int x)
    {
        int s = 0;
        for (int i = 1; i <= x; i++)
            if (x % i == 0) s += i;
        return s;
    }

    static int MaxDivisorSum(int n)
    {
        int best = 2, bestSum = SumDivisors(2);
        for (int i = 3; i <= n; i++)
        {
            int s = SumDivisors(i);
            if (s > bestSum) { bestSum = s; best = i; }
        }
        return best;
    }

    // Задача 3: взаимно простые ли 3 числа
    static int Gcd(int a, int b)
    {
        while (b != 0) { int t = b; b = a % b; a = t; }
        return a;
    }

    static bool AreCoprime(int a, int b, int c)
    {
        return Gcd(Gcd(a, b), c) == 1;
    }

    // Задача 4: среднее геометрическое модулей и среднее арифметическое пар
    static double GeomMeanAbs(double a, double b, double c)
    {
        return Math.Pow(Math.Abs(a * b * c), 1.0 / 3.0);
    }

    static double Avg(double a, double b) => (a + b) / 2.0;

    // Задача 5: след матрицы
    static double Trace(double[,] m)
    {
        double s = 0;
        for (int i = 0; i < m.GetLength(0); i++) s += m[i, i];
        return s;
    }

    static void Main()
    {
        // --- Задача 1 ---
        Console.WriteLine("Задача 1");
        Console.Write("a = "); double a1 = double.Parse(Console.ReadLine());
        Console.Write("b = "); double b1 = double.Parse(Console.ReadLine());
        Console.Write("c = "); double c1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Сумма max+min = " + SumMaxMin(a1, b1, c1));

        // --- Задача 2 ---
        Console.WriteLine("\nЗадача 2");
        Console.Write("n = "); int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Число с макс. суммой делителей: " + MaxDivisorSum(n));

        // --- Задача 3 ---
        Console.WriteLine("\nЗадача 3");
        Console.Write("a = "); int a3 = int.Parse(Console.ReadLine());
        Console.Write("b = "); int b3 = int.Parse(Console.ReadLine());
        Console.Write("c = "); int c3 = int.Parse(Console.ReadLine());
        Console.WriteLine("Взаимно простые: " + AreCoprime(a3, b3, c3));

        // --- Задача 4 ---
        Console.WriteLine("\nЗадача 4");
        Console.Write("a = "); double x = double.Parse(Console.ReadLine());
        Console.Write("b = "); double y = double.Parse(Console.ReadLine());
        Console.Write("c = "); double z = double.Parse(Console.ReadLine());
        Console.WriteLine("Ср. геом. модулей = " + GeomMeanAbs(x, y, z));
        Console.WriteLine("Ср. арифм. (a,b) = " + Avg(x, y));
        Console.WriteLine("Ср. арифм. (a,c) = " + Avg(x, z));
        Console.WriteLine("Ср. арифм. (b,c) = " + Avg(y, z));

        // --- Задача 5 ---
        Console.WriteLine("\nЗадача 5");
        Console.Write("Размер A: "); int na = int.Parse(Console.ReadLine());
        Console.Write("Размер B: "); int nb = int.Parse(Console.ReadLine());

        double[,] A = new double[na, na];
        double[,] B = new double[nb, nb];

        Console.WriteLine("Введите матрицу A:");
        for (int i = 0; i < na; i++)
            for (int j = 0; j < na; j++)
                A[i, j] = double.Parse(Console.ReadLine());

        Console.WriteLine("Введите матрицу B:");
        for (int i = 0; i < nb; i++)
            for (int j = 0; j < nb; j++)
                B[i, j] = double.Parse(Console.ReadLine());

        double c = Trace(A);
        double d = Trace(B);

        Console.WriteLine("x\t y = c*x^2 + d");
        for (double x2 = 0; x2 <= 1.0001; x2 += 0.1)
            Console.WriteLine($"{x2:F1}\t {c * x2 * x2 + d:F4}");
    }
}