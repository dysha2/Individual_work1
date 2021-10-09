using System;
using System.IO;
using System.Collections;

namespace Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("file.txt"))
            {
                int a, b;
                for (; ; )
                {
                    try
                    {
                        Console.WriteLine("Введите 2 числа");
                         a = int.Parse(Console.ReadLine());
                         b = int.Parse(Console.ReadLine());
                        break;
                    } catch { Console.WriteLine("Вы введи некорректные данные"); }
                }
                if (a>b)
                {
                    int c = a;
                    a = b;
                    b = c;
                }
                StreamReader sr = new StreamReader("file.txt");
                string s = sr.ReadToEnd();
                sr.Close();
                Queue between = new Queue();
                Queue before = new Queue();
                Queue after = new Queue();
                string[] s2 = s.Split(" ");
                for (int i=0;i<s2.Length;i++)
                {
                    try
                    {
                        int num = int.Parse(s2[i]);
                        if (num<a)
                        {
                            before.Enqueue(num);
                        } else
                        {
                            if (num>b)
                            {
                                after.Enqueue(num);
                            } else
                            {
                                between.Enqueue(num);
                            }
                        }
                    }
                    catch { Console.WriteLine($"Элемент {s2[i]} некорректно записан"); }
                }
                Console.WriteLine($"Числа стоящие между {a} и {b}");
                while(between.Count>0)
                {
                    Console.Write($"{between.Dequeue()} ");
                }
                Console.WriteLine();
                Console.WriteLine($"Числа меньшие {a}");
                while (before.Count > 0)
                {
                    Console.Write($"{before.Dequeue()} ");
                }
                Console.WriteLine();
                Console.WriteLine($"Числа большие {b}");
                while (after.Count > 0)
                {
                    Console.Write($"{after.Dequeue()} ");
                }
            }
            else
            {
                Console.WriteLine("Исходный файл не найден");
            }
        }
    }
}
