using System;
using System.Collections.Generic;

namespace Day1Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string filepath = "C:/Users/kristoffer.boe/Documents/Kristoffer_Bouvet/AdventOfCode/Day1/Day1Data.txt";

            string[] entries_string = System.IO.File.ReadAllLines(filepath);
            int[] entries = ConvertStringArrayToIntArray(entries_string);

            var result_day1_task1 = TwoNumbersThatAddUpTo2020Multiplied(entries);
            var result_day1_task2 = ThreeNumbersThatAddUpTo2020Multiplied(entries);

            Console.WriteLine(result_day1_task1);
            Console.WriteLine(result_day1_task2);
        }

        public static int[] ConvertStringArrayToIntArray(string[] string_array)
        {
            List<int> entries_list = new List<int>();

            foreach (string line in string_array)
            {
                entries_list.Add(Convert.ToInt32(line));
            }

            int[] entries = entries_list.ToArray();
            return entries;
        }

        public static int TwoNumbersThatAddUpTo2020Multiplied(int[] entries)
        {
            for (int i = 0; i < entries.Length; i++)
            {
                for (int j = i + 1; j < entries.Length; j++)
                {
                    if (entries[i] + entries[j] == 2020)
                    {
                        Console.WriteLine(entries[i].ToString() + " + " + entries[j] + "=" + (entries[i] + entries[j]).ToString());
                        return entries[i] * entries[j];
                    }
                }
            }
            return -1;
        }
        public static int ThreeNumbersThatAddUpTo2020Multiplied(int[] entries)
        {
            for (int x = 0; x < entries.Length; x++)
            {
                for (int y = x + 1; y < entries.Length; y++)
                {
                    for (int z = y+1; z < entries.Length; z++)
                    {
                        if (entries[x] + entries[y] + entries[z] == 2020)
                        {
                            Console.WriteLine(entries[x].ToString() + " + " + entries[y] + " + " + entries[z] + "=" + (entries[x] + entries[y] + entries[z]).ToString());
                            return entries[x] * entries[y] * entries[z];
                        }
                    }
                }
            }
            return -1;
        }
    }
}
