using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = { "что", "говорить", "делать", "жить", "дом", "мама" };
            Console.WriteLine("Массив содержит слова:");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            char c = 'а';
            int result_i = 0;
            int max_count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int count = 0;
                foreach (var ch in array[i].ToCharArray())
                {
                    if (c == ch)
                    {
                        count++;
                    }
                }
                if (count > max_count)
                {
                    result_i = i;
                    max_count = count;
                }
            }
            Console.WriteLine($"\nБольше всего символов '{c}' содержится с слове {array[result_i]}");
            Console.WriteLine(array[result_i]);
            Console.ReadLine();
        }
    }
}
