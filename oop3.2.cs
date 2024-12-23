using System;

class Program
{
    static void Main()
    {

        Random rnd = new Random();

        Console.Write("Введіть кількість рядків (n): ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Введіть кількість стовпців (m): ");
        int m = int.Parse(Console.ReadLine());

        double[,] array = new double[n, m];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                array[i, j] = Math.Round(rnd.NextDouble() * (126.3 + 12.3) - 12.3, 1);
            }
        }

        Console.WriteLine("\nІніціалізований масив:");
        PrintArray(array);

        double[] columnSums = new double[m];
        double maxSum = double.MinValue;
        for (int j = 0; j < m; j++)
        {
            double columnSum = 0;
            for (int i = 0; i < n; i++)
            {
                columnSum += array[i, j];
            }
            columnSums[j] = columnSum;
            if (columnSum > maxSum)
            {
                maxSum = columnSum;
            }
        }

        Console.WriteLine("\nСуми елементів кожного стовпця:");
        for (int j = 0; j < m; j++)
        {
            Console.WriteLine($"Сума стовпця {j + 1}: {columnSums[j]}");
        }
        Console.WriteLine($"Найбільша сума стовпця: {maxSum}");

        for (int i = 0; i < n / 2; i++)
        {
            for (int j = 0; j < m; j++)
            {
                double temp = array[i, j];
                array[i, j] = array[n - 1 - i, j];
                array[n - 1 - i, j] = temp;
            }
        }

        Console.WriteLine("\nМасив після обміну рядків:");
        PrintArray(array);
    }

    static void PrintArray(double[,] array)
    {
        int n = array.GetLength(0);
        int m = array.GetLength(1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"{array[i, j],6:F1}\t");
            }
            Console.WriteLine();
        }
    }
}
