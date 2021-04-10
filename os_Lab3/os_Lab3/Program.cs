using System;
using System.Collections.Generic;

namespace os_Lab3
{
    static class Program
    {
        private static List<int> pages = new List<int> { 7, 8, 9, 2, 1, 0, 8, 9, 2, 4, 6, 8, 2, 1, 8, 9 }; // номера страниц

        private static List<int> memoryFIFO4 = new List<int> { 8, 2, 9, 6 }; // содержимое памяти из 4 ячеек FIFO
        private static List<int> memoryFIFO5 = new List<int> { 8, 2, 9, 6, -1 }; // содержимое памяти из 5 ячеек, пятая - пустая FIFO

        private static List<int> memoryLRU4 = new List<int> { 8, 2, 9, 6 }; // содержимое памяти из 4 ячеек LRU
        private static List<int> memoryLRU5 = new List<int> { 8, 2, 9, 6, -1 }; // содержимое памяти из 5 ячеек, пятая - пустая LRU

        // листы счетчиков прерываний
        private static List<int> analisysFour = new List<int> { int.MaxValue, int.MaxValue }; //0 - FIFO4, 1 - LRU4,
        private static List<int> analisysFife = new List<int> { int.MaxValue, int.MaxValue }; //0 - FIFO5, 1 - LRU5


        private static void InputOutput(int pagesCount, List<int> memory) // ввод вывод начальных данных
        {
            Console.WriteLine("Содержимое обращений:");
            for (int i = 0; i < pagesCount; i++)
            {
                Console.WriteLine("{0}) {1}", i + 1, pages[i]);
            }
            Console.WriteLine("");

            Console.Write("Содержимое памяти: ");
            for (int i = 0; i < memory.Count; i++)
            {
                Console.Write(memory[i] + " ");

            }
            Console.WriteLine("\n");
        }

        static void Main()
        {
            //FIFO
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nFIFO4", analisysFour[0]); // название метода и кол-во страниц в памяти
            Console.ForegroundColor = ConsoleColor.Gray;
            InputOutput(16, memoryFIFO4); // вывод информации
            analisysFour[0] = FIFO.FourPlacesInMemory(pages, memoryFIFO4); // работа алгоритма
            Console.WriteLine("\nНажмите любую клавишу для продолжения ");
            Console.ReadKey();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nFIFO5", analisysFour[0]);
            Console.ForegroundColor = ConsoleColor.Gray;
            InputOutput(16, memoryFIFO5);
            analisysFife[0] = FIFO.FifePlacesInMemory(pages, memoryFIFO5);
            Console.WriteLine("\nНажмите любую клавишу для продолжения ");
            Console.ReadKey();
            Console.Clear();

            //LRU
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nLRU4", analisysFour[0]);
            Console.ForegroundColor = ConsoleColor.Gray;
            InputOutput(16, memoryLRU4);
            analisysFour[1] = LRU.FourPlacesInMemory(pages, memoryLRU4);
            Console.WriteLine("\nНажмите любую клавишу для продолжения ");
            Console.ReadKey();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nLRU5", analisysFour[0]);
            Console.ForegroundColor = ConsoleColor.Gray;
            InputOutput(16, memoryLRU5);
            analisysFife[1] = LRU.FifePlacesInMemory(pages, memoryLRU5);
            Console.WriteLine("\nНажмите любую клавишу для продолжения ");
            Console.ReadKey();
            Console.Clear();

            //Анализ алгоритмов
            if (analisysFour[0] < analisysFour[1])
                Console.WriteLine("\nВ данной случае для памяти из 4 ячеек лучший алгоритм - FIFO. Кол-во прерываний: {0}", analisysFour[0]);
            else
                Console.WriteLine("\nВ данной случае для памяти из 4 ячеек лучший алгоритм - LRU. Кол-во прерываний: {0}", analisysFour[1]);

            if (analisysFife[0] < analisysFife[1])
                Console.WriteLine("\nВ данной случае для памяти из 5 ячеек лучший алгоритм - FIFO. Кол-во прерываний: {0}", analisysFife[0]);
            else
                Console.WriteLine("\nВ данной случае для памяти из 5 ячеек лучший алгоритм - LRU. Кол-во прерываний: {0}", analisysFife[1]);

            analisysFour.Clear(); // очистка списка результатов для 4 страниц в памяти
            analisysFife.Clear(); // очистка списка результатов для 5 страниц в памяти

            Console.ReadKey();
        }
    }
}

