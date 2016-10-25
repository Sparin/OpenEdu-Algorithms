using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("queue.out", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            string[] stdin = File.ReadAllLines("queue.in");

            Queue queue = new Queue(); 

            for(int i = 1; i < stdin.Length; i++)
                if (stdin[i][0] == '+')
                queue.Enqueue(long.Parse(stdin[i].Split(' ')[1]));
            else
                sw.WriteLine(queue.Dequeue());

            sw.Dispose();
        }
    }

    //Функционал исключительно под условие задачи
    class Queue
    {
        private long[] array = new long[1000000];
        private long head;
        private long tail;

        public void Enqueue(long value)
        {
            array[tail++] = value;
        }

        public long Dequeue()
        {
            return array[head++];
        }
    }
}
