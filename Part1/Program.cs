using System;
using System.IO;
using System.Collections;

namespace Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("file.txt"))
            {
                StreamReader sr = new StreamReader("file.txt");
                string s = sr.ReadToEnd();
                sr.Close();
                Stack st = new Stack();
                string abc = "аеёиоуыяюэ";
                for (int i=0;i<s.Length;i++)
                {
                    if ((abc.Contains(s[i]))||(abc.ToUpper().Contains(s[i]))) st.Push(s[i]);
                }
                Console.WriteLine("Глассные из файла в обратном порядке");
                while (st.Count > 0)
                {
                    Console.Write($"{st.Pop()} ");
                }
            } else
            {
                Console.WriteLine("Исходный файл не найден");
            }
        }
    }
}
