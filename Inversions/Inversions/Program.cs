using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Inversions
{
    class Program
    {
        static long Inversions = 0;

        static void Main(string[] args)
        {
            FileStream fs = new FileStream("inversions.out", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            Console.SetOut(sw);

            string[] stdin = File.ReadAllLines("inversions.in");

            long[] sort = stdin[1].Split(' ').Select(x => long.Parse(x)).ToArray();
            MergeSort(ref sort, 0, sort.Length - 1);
            Console.WriteLine(Inversions);

            sw.Dispose();
        }

        static void MergeSort(ref long[] array, long startIndex, long endIndex)
        {
            if (endIndex - startIndex == 0)
                return;
            long middleIndex = (endIndex + startIndex) / 2;
            MergeSort(ref array, startIndex, middleIndex);
            MergeSort(ref array, middleIndex + 1, endIndex);
            Merge(ref array, startIndex, middleIndex, endIndex);
        }

        static void Merge(ref long[] array, long startIndex, long middleIndex, long endIndex)
        {
            long[] result = new long[endIndex - startIndex + 1];
            long li = 0, ri = 0;

            while (li < middleIndex - startIndex + 1 && ri < endIndex - middleIndex)
                if (array[startIndex + li] <= array[middleIndex + ri + 1])
                    result[ri + li] = array[startIndex + li++];
                else
                {
                    Inversions += middleIndex - startIndex - li + 1;
                    result[ri + li] = array[middleIndex + ++ri];
                }

            while (li < middleIndex - startIndex + 1)
                result[ri + li] = array[startIndex + li++];

            while (ri < endIndex - middleIndex)
                result[ri + li] = array[middleIndex + ++ri];

            for (int i = 0; i < result.Length; i++)
                array[startIndex + i] = result[i];
        }
    }
}
