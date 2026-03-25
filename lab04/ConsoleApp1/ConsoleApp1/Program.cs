using System;
class Programm
{
    static int N = 100000;
    public static double[] MKG()
    {
        double beta = Math.Pow(2, 32) + 3;

        double M = Math.Pow(2, 63);

        double[] x_calculated = new double[N];
        double[] x = new double[N];

        x_calculated[0] = beta;

        for (int i = 0; i < N; i++)
        {
            x[i] = x_calculated[i] / M;
            if (i < N - 1)
            {
                x_calculated[i + 1] = (x_calculated[i] * beta) % M;
            }
        }
        return x;
    }

    public static double[] Fibonacci()
    {
        double[] x = new double[N];

        double x_prev1 = 1.0;
        double x_prev2 = 1.0;
        double mod = N;

        x[0] = x_prev2 / mod;
        x[1] = x_prev1 / mod;

        for (int i = 2; i < N; i++)
        {
            double x_next = (x_prev1 + x_prev2) % mod;
            x[i] = x_next / mod;

            x_prev2 = x_prev1;
            x_prev1 = x_next;
        }

        return x;
    }

    public static double[] RealRandom()
    {
        Random rnd = new Random();
        double [] x = new double[N];
        for (int i = 0; i < N; i++)
        {
            x[i] = rnd.NextDouble();
        }

        return x;
    }
    public static double CalculateMean(double[] data)
    {
        double sum = 0.0;
        foreach (double value in data)
        {
            sum += value;
        }
        return sum / data.Length;
    }

    public static double CalculateVariance(double[] data)
    {
        double mean = CalculateMean(data);
        double sumOfSquares = 0.0;
        foreach (double value in data)
        {
            sumOfSquares += Math.Pow(value - mean, 2);
        }
        return sumOfSquares / (data.Length - 1);
    }

    static void Main(string[] args)
    {
        double[] resultMKG = MKG();
        double[] resultFibonacci = Fibonacci();
        double[] resultRealRandom = RealRandom();

        double rand_mean, rand_var, mkg_mean, mkg_var, fib_mean, fib_var, teor_mean, teor_var;

        teor_mean = 0.5;
        teor_var = 1.0 / 12.0;

        rand_mean = CalculateMean(resultRealRandom);
        rand_var = CalculateVariance(resultRealRandom);

        fib_mean = CalculateMean(resultFibonacci);
        fib_var = CalculateVariance(resultFibonacci);

        mkg_mean = CalculateMean(resultMKG);
        mkg_var = CalculateVariance(resultMKG);

        Console.WriteLine("Теоретические значения для равномерного распределения на [0, 1]:");
        Console.WriteLine($"- Среднее: {teor_mean:F6}");
        Console.WriteLine($"- Дисперсия: {teor_var:F6}\n");

        Console.WriteLine("Выборочные значения для метода RealRandom:");
        Console.WriteLine($"- Среднее: {rand_mean:F6} (отклонение от теоретического: {rand_mean - teor_mean:F6})");
        Console.WriteLine($"- Дисперсия: {rand_var:F6} (отклонение от теоретического: {rand_var - teor_var:F6})\n");

        Console.WriteLine("Выборочные значения для метода Fibonacci:");
        Console.WriteLine($"- Среднее: {fib_mean:F6} (отклонение от теоретического: {fib_mean - teor_mean:F6})");
        Console.WriteLine($"- Дисперсия: {fib_var:F6} (отклонение от теоретического: {fib_var - teor_var:F6})\n");

        Console.WriteLine("Выборочные значения для метода MKG:");
        Console.WriteLine($"- Среднее: {mkg_mean:F6} (отклонение от теоретического: {mkg_mean - teor_mean:F6})");
        Console.WriteLine($"- Дисперсия: {mkg_var:F6} (отклонение от теоретического: {mkg_var - teor_var:F6})");
    }
}



