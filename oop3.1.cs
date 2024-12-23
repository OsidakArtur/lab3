using System;
using System.Linq;

class Program
{
    static void Main()
    {
        double[] numbers = { -110.34, 22.5, -45.67, 18.9, -12.3, 45.6, -78.9, 56.4 };


        double negativeSum = 0;
        for (int i = 0; i < numbers.Length; i += 2) 
        {
            if (numbers[i] < 0)
            {
                negativeSum += numbers[i];
            }
        }
        Console.WriteLine($"Сума від’ємних елементів з парними індексами: {negativeSum:F2}");

        var oddIndexedNumbers = numbers.Where((x, index) => index % 2 != 0).ToArray();
        Array.Sort(oddIndexedNumbers);
        Array.Reverse(oddIndexedNumbers);

        int oddIndex = 1;
        foreach (var num in oddIndexedNumbers)
        {
            numbers[oddIndex] = num;
            oddIndex += 2; 
        }

        Console.WriteLine("Масив після сортування елементів з непарними індексами:");
        foreach (var num in numbers)
        {
            Console.Write($"{num:F2} \t");
        }
        Console.WriteLine();
    }
}
