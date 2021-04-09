using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace os_Lab3
{
    class FIFO
    {
        private static int counterInterruption = 0;

        public static int FourPlacesInMemory(List<int> pages, List<int> memory)
        {
            counterInterruption = 0;
            for (int k = 0; k < pages.Count; k++) // пробегаем по всем обращениям
            {
                string interruptionTag = "     "; // тэг отсутствия прерывания (5 пробелов не просто так)

                if (!memory.Contains(pages[k]))// если память не содержит страницу из обращения
                {
                    counterInterruption++; // организовываем прерывание
                    for (int i = 0; i < memory.Count - 1; i++)
                    {
                        memory[i] = memory[i + 1]; // всю память сдвигаем выбрасывая самый старый элемент
                    }
                    memory[memory.Count-1] = pages[k]; // самый новый элемент это собственно страница к которой сейчас обращаемся
                    interruptionTag = "[ПР] "; // тег прерывания теперь говорит о том что здесь оно было
                }
                Console.WriteLine("{0}Номер обращения: {1}, Страница: {2} Память: {3}", 
                    interruptionTag, k, pages[k], string.Join(",", memory)); // вывод информации о данном обращении
            }
            Console.Write("\n");
            Console.WriteLine("Общее количество прерываний: {0} \n", counterInterruption);
            return counterInterruption;// возврат общего кол-ва прерываний для анализа
        }

        public static int FifePlacesInMemory(List<int> pages, List<int> memory)
        {
            counterInterruption = 0;
            for (int k = 0; k < pages.Count; k++) // все обращения
            {
                string interruptionTag = "     "; // пустой тэг прерывания
                if (!memory.Contains(pages[k])) // если нет в памяти
                {
                    counterInterruption++; // +1 прерывание
                    if (memory[memory.Count - 1] != -1) // если последняя ячейка НЕ пуста
                    {
                        for (int i = 0; i < memory.Count - 1; i++)
                        {
                            memory[i] = memory[i + 1]; // проталкиваем все вперед, старый выбрасываем
                        }
                        memory[memory.Count - 1] = pages[k]; // самый новый - это то куда обращаемся на этом шаге
                    }
                    else
                    {
                        memory[memory.Count - 1] = pages[k]; // если  последняя ячейка ПУСТА то не проталкивая туда просто записываем обращение
                    }
                    interruptionTag = "[ПР] "; // тэг прерывания говорит о том что оно было
                }
                Console.WriteLine("{0}Номер обращения: {1}, Страница: {2}, Память: {3}", 
                    interruptionTag, k, pages[k], string.Join(",", memory)); // вывод информации о данном обращении
            }
            Console.Write("\n");
            Console.WriteLine("Общее количество прерываний: {0} \n", counterInterruption);
            return counterInterruption;// возврат общего кол-ва прерываний для анализа
        }
    }
}
