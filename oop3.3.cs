using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace ArrayProcessing
{
    public partial class MainWindow : Window
    {
        public MainWindow2()
        {
            InitializeComponent();
        }

        private void ProcessArray_Click1(object sender, RoutedEventArgs e)
        {
            double[] numbers = { -110.34, 22.5, -45.67, 18.9, -12.3, 45.6, -78.9, 56.4 };

            InitialArrayText.Text = string.Join(", ", numbers.Select(n => n.ToString("F2")));

            double negativeSum = 0;
            for (int i = 0; i < numbers.Length; i += 2)
            {
                if (numbers[i] < 0)
                {
                    negativeSum += numbers[i];
                }
            }

            NegativeSumText.Text = $"Сума від’ємних елементів: {negativeSum:F2}";

            var oddIndexedNumbers = numbers.Where((x, index) => index % 2 != 0).ToArray();
            Array.Sort(oddIndexedNumbers);
            Array.Reverse(oddIndexedNumbers);

            int oddIndex = 1;
            foreach (var num in oddIndexedNumbers)
            {
                numbers[oddIndex] = num;
                oddIndex += 2;
            }

            SortedArrayText.Text = string.Join(", ", numbers.Select(n => n.ToString("F2")));

            SaveResultsToFile(numbers, negativeSum);
        }

        private void SaveResultsToFile(double[] numbers, double negativeSum)
        {
            string folderPath = @"C:\Users\dimapaken\Desktop\Лаб 24\ООП\LAB3 oop";
            Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, "Results.txt");

            string results = $"Початковий масив: {string.Join(", ", numbers.Select(n => n.ToString("F2")))}\n" +
                             $"Сума від’ємних елементів з парними індексами: {negativeSum:F2}\n" +
                             $"Масив після сортування елементів з непарними індексами: {string.Join(", ", numbers.Select(n => n.ToString("F2")))}";

            File.WriteAllText(filePath, results);

            MessageBox.Show($"Результати збережено у файл:\n{filePath}", "Збереження", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
