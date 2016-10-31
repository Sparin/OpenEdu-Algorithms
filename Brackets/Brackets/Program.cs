using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("brackets.out", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            string[] stdin = File.ReadAllLines("brackets.in");

            for (int i = 0; i < stdin.Length; i++)
            {
                bool legal = true;
                Stack<char> brackets = new Stack<char>();
                for (int j = 0; j < stdin[i].Length; j++)
                    switch (stdin[i][j])
                    {
                        case '(':
                            brackets.Push(stdin[i][j]);
                            break;
                        case '[':
                            brackets.Push(stdin[i][j]);
                            break;
                        case ')':
                            if (brackets.Count==0||brackets.Peek() != '(')
                                legal = false;
                            if (brackets.Count != 0)
                            brackets.Pop();
                            break;
                        case ']':
                            if (brackets.Count == 0 || brackets.Peek() != '[')
                                legal = false;
                            if (brackets.Count != 0)
                                brackets.Pop();
                            break;
                    }
                if (legal && brackets.Count == 0)
                    sw.WriteLine("YES");
                else
                    sw.WriteLine("NO");
            }

            sw.Dispose();
        }
    }
}
