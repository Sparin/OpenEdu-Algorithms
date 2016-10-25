using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("stack.out", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            string[] stdin = File.ReadAllLines("stack.in");

            Stack stack = new Stack();

            for (int i = 1; i < stdin.Length; i++)
                if (stdin[i][0] == '+')
                    stack.Push(long.Parse(stdin[i].Split(' ')[1]));
                else
                    sw.WriteLine(stack.Pop());

            sw.Dispose();
        }
    }

    //Функционал исключительно под условие задачи
    class Stack
    {
        public long Top { get; set; }

        public long Pop()
        {
            return array[--Top];
        }

        public void Push(long value)
        {
            array[Top++] = value;
        }

        private long[] array = new long[1000000];
    }
}
