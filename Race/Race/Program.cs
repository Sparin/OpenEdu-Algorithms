using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Race
{
    struct Racer
    {
        public int Position { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }

    class Program
    {

        static void Main()
        {
            FileStream fs = new FileStream("race.out", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            Console.SetOut(sw);

            string[] stdin = File.ReadAllLines("race.in");
            List<Racer> racers = new List<Racer>();
            for (int i = 1; i < stdin.Length; i++)
            {
                string[] args = stdin[i].Split(' ');
                racers.Add(new Racer { Position = i, Country = args[0], Name = args[1] });
            }

            MergeSort(ref racers, 0, racers.Count - 1);

            string currentCountry = string.Empty;
            for (int i = 0; i < racers.Count; i++)
            {
                if (currentCountry != racers[i].Country)
                {
                    currentCountry = racers[i].Country;
                    Console.WriteLine("=== {0} ===", currentCountry);
                }
                Console.WriteLine(racers[i].Name);
            }

            sw.Dispose();
        }

        static void MergeSort(ref List<Racer> array, int startIndex, int endIndex)
        {
            if (endIndex - startIndex == 0)
                return;

            int middleIndex = (endIndex + startIndex) / 2;
            MergeSort(ref array, startIndex, middleIndex);
            MergeSort(ref array, middleIndex + 1, endIndex);
            Merge(ref array, startIndex, middleIndex, endIndex);
        }

        static void Merge(ref List<Racer> array, int startIndex, int middleIndex, int endIndex)
        {
            Racer[] result = new Racer[endIndex - startIndex + 1];
            int li = 0, ri = 0;
            
            while (li < middleIndex - startIndex + 1 && ri < endIndex - middleIndex)
                if (string.CompareOrdinal(array[startIndex + li].Country, array[middleIndex + ri + 1].Country) <=0)
                    result[ri + li] = array[startIndex + li++];
                else
                    result[ri + li] = array[middleIndex + ++ri];

            while (li < middleIndex - startIndex + 1)
                result[ri + li] = array[startIndex + li++];

            while (ri < endIndex - middleIndex)
                result[ri + li] = array[middleIndex + ++ri];

            for (int i = 0; i < result.Length; i++)
                array[startIndex + i] = result[i];
        }
    }
}
