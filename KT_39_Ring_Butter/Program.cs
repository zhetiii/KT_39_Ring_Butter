using System;

namespace KT_39
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== КОЛЬЦЕВОЙ БУФЕР (ПОЛЬЗОВАТЕЛЬСКИЙ ИТЕРАТОР) ===\n");

            Console.Write("Введите фиксированную емкость буфера: ");
            int capacity = int.TryParse(Console.ReadLine(), out int parsedCap) && parsedCap > 0 ? parsedCap : 3;

            CircularBuffer<int> buffer = new CircularBuffer<int>(capacity);
            Console.WriteLine($"Создан кольцевой буфер емкостью {capacity}.\n");

            Console.WriteLine("Сколько элементов вы хотите добавить в буфер? :");
            Console.Write("Количество элементов: ");
            int countInput = int.TryParse(Console.ReadLine(), out int parsedCount) && parsedCount > 0 ? parsedCount : 5;

            Console.WriteLine($"Введите {parsedCount} элементов по одному:");
            for (int i = 0; i < parsedCount; i++)
            {
                Console.Write($"Элемент {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out int val))
                {
                    buffer.Add(val);
                }
            }

            Console.WriteLine("\n--- Обход через foreach (от старого к новому) ---");
            Console.Write("Буфер содержит: ");
            foreach (var item in buffer)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            Console.WriteLine("\n--- Обход через Reverse() (от нового к старому) ---");
            Console.Write("Буфер в обратном порядке: ");
            foreach (var item in buffer.Reverse())
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("\n\nРабота программы успешно завершена.");
        }
    }
}