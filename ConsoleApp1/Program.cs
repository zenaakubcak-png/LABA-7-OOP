using System;
using Yakubchak_IP55_Lab7.DataStructures;

namespace Yakubchak_IP55_Lab7.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Демонстрація роботи власної структури даних (Варіант 11) ===");

            FloatSinglyLinkedList list = new FloatSinglyLinkedList();

            // Додаємо елементи. 
            // Пам'ятаємо: за алгоритмом елементи вставляються ПІСЛЯ другого!
            list.Add(5.5f);   // 1-й
            list.Add(-3.2f);  // 2-й
            list.Add(10.1f);  // Вставиться після 2-го (стане 3-м)
            list.Add(-1.5f);  // Вставиться після 2-го (стане новим 3-м, а 10.1f стане 4-м)
            list.Add(8.0f);   // Вставиться після 2-го (стане новим 3-м)

            Console.WriteLine("\nПоточний список (використання foreach):");
            PrintList(list);

            Console.WriteLine("\nДемонстрація доступу за індексом (читання list[2]):");
            Console.WriteLine($"Елемент з індексом 2: {list[2]}");

            Console.WriteLine("\nВидалення елемента за індексом 1...");
            list.RemoveAt(1); // Видаляємо -3.2f
            PrintList(list);

            // Параметризація літералів, як вимагається у завданні
            float zeroThreshold = 0.0f;

            Console.WriteLine("\n--- Операції за варіантом ---");

            // 1. Знайти перший від'ємний елемент
            float? firstNegative = list.FindFirstLessThan(zeroThreshold);
            if (firstNegative.HasValue)
                Console.WriteLine($"1. Перший від'ємний елемент: {firstNegative.Value}");
            else
                Console.WriteLine("1. Від'ємних елементів не знайдено.");

            // 2. Знайти суму елементів більших за середнє значення
            float sumGreaterAvg = list.SumGreaterThanAverage();
            Console.WriteLine($"2. Сума елементів, більших за середнє значення: {sumGreaterAvg}");

            // 3. Отримати новий список зі значень позитивних елементів
            Console.WriteLine("3. Новий список лише з позитивних елементів:");
            FloatSinglyLinkedList positiveList = list.GetElementsGreaterThan(zeroThreshold);
            PrintList(positiveList);

            // 4. Видалити всі від'ємні елементи поточного списку
            Console.WriteLine("4. Видалення всіх від'ємних елементів з початкового списку...");
            list.RemoveAllLessThan(zeroThreshold);
            PrintList(list);

            Console.WriteLine("\n=== Демонстрація роботи з другим об'єктом списку ===");
            FloatSinglyLinkedList list2 = new FloatSinglyLinkedList();
            list2.Add(1.1f);
            list2.Add(2.2f);
            list2.Add(3.3f);
            Console.WriteLine("Другий список створено успішно:");
            PrintList(list2);

            Console.ReadLine();
            
        }

        /// <summary>
        /// Допоміжний метод для зручного виведення списку.
        /// </summary>
        static void PrintList(FloatSinglyLinkedList list)
        {
            Console.Write("[ ");
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine($"] (Кількість: {list.Count})");
        }
    }
}
