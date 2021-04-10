using System;
using System.Collections.Generic;

namespace os_Lab3
{
    class LRU
    {
        private static int counterInterruption = 0;
        public static int FourPlacesInMemory(List<int> pages, List<int> memory)
        {
            counterInterruption = 0;
            for (int k = 0; k < pages.Count; k++) // проход по всем обращениям
            {
                string interruptionTag = "     "; // пустой тэг прерывания

                if (!memory.Contains(pages[k])) // если НЕТ в памяти
                {
                    counterInterruption++; // +1 прерывание
                    for (int i = 0; i < memory.Count - 1; i++) // проталкиваем все, удаляем старое
                    {
                        memory[i] = memory[i + 1];
                    }
                    memory[memory.Count - 1] = pages[k]; // записываем новое (тут все аналогично с ФИФО)
                    interruptionTag = "[ПР] "; // тэг прерывания
                }
                else // если все таки БЫЛО в памяти
                {
                    int temp = memory.IndexOf(pages[k]); // запоминаем где было в памяьт
                    int swaping = memory[temp]; // запоминаем что там было
                    for (int i = temp; i < memory.Count - 1; i++) // начиная от места где БЫЛО в памяти и до ее конца (i от temp)
                    {
                        memory[i] = memory[i + 1]; // сдвигаем удаляя старый
                    }
                    memory[memory.Count - 1] = swaping; // самое новое - то что переместили внутри памяти
                    // при этом прерывания не произошло, поэтому тэг остаётся пустым
                }
                Console.WriteLine("{0}Номер обращения: {1}, Страница: {2}, Память: {3}", 
                    interruptionTag, k, pages[k], string.Join(",", memory)); // информация о шаге
            }
            Console.Write("\n");
            Console.WriteLine("Общее количество прерываний: {0} \n", counterInterruption);
            return counterInterruption;
        }

        public static int FifePlacesInMemory(List<int> pages, List<int> memory)
        {
            counterInterruption = 0;
            for (int k = 0; k < pages.Count; k++)
            {
                string interruptionTag = "     ";

                if (!memory.Contains(pages[k])) // // если НЕТ в памяти
                {
                    counterInterruption++; // +1 прерывание
                    if (memory[memory.Count - 1] != -1) // если последняя ячейка НЕ пуста
                    {
                        for (int i = 0; i < memory.Count - 1; i++)
                        {
                            memory[i] = memory[i + 1]; // делаем все аналогично ФИФО
                        }
                        memory[memory.Count - 1] = pages[k]; // самое новое - то куда обращаемся

                    }
                    else
                        memory[memory.Count - 1] = pages[k]; // если последняя ячейка БЫЛА ПУСТА, то в нее запишем то куда обращаемся
                    interruptionTag = "[ПР] "; // в любом случае произойдет прерывание, т.к. в памяти не было нужной страницы
                }
                else // если в памяти БЫЛА НУЖНАЯ СТРАНИЦА
                {
                    int n;
                    if (memory.Contains(-1)) // если при этом еще и есть пустая ячейка
                        n = 2; // сдвиг = 2
                    else // если нет
                        n = 1; // сдвиг = 1

                    int temp = memory.IndexOf(pages[k]); // запомнили откуда переносим
                    int swaping = memory[temp]; // запомнили что переносим
                    for (int i = temp; i < memory.Count - n; i++) // от места переноса, до места в памяти учитывая СДВИГ
                    {
                        memory[i] = memory[i + 1]; // все смещаем, удаляя старое
                    }
                    memory[memory.Count - n] = swaping; // перемещаем внутри памяти
                }
                // прерывания нет в данном случае, т.к. все есть в памяти
                // СДВИГ необходимо учитывать, чтобы пустая ячейка не поползла вглубь памяти, а всегда оставалсь в конце
                // чтобы ее можно было занять при будущей подгрузке в память нужной страницы
                // чтобы посмотреть как  и зачем это: поставьте в ЛИСТЕ pages нулевой элемент например 9

                Console.WriteLine("{0}Номер обращения: {1}, Страница: {2}, Память: {3}", 
                    interruptionTag, k, pages[k], string.Join(",", memory)); // вывод информации о шаге
            }
            Console.Write("\n");
            Console.WriteLine("Общее количество прерываний: {0} \n", counterInterruption);
            return counterInterruption;
        }
    }
}
