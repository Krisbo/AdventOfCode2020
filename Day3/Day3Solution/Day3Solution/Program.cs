using System;

namespace Day3Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            string filepath = "C:/Users/kristoffer.boe/krisbo_git/AdventOfCode2020/Day3/Day3Data.txt";
            string[] entries = System.IO.File.ReadAllLines(filepath);

            int number_of_trees_encountered = getNumberOfEncounteredTrees(entries);

            Console.WriteLine("Number of trees: " + number_of_trees_encountered);
        }

        private static int getNumberOfEncounteredTrees(string[] entries)
        {
            int length_of_data_per_line = entries[0].Length;
            int steps_to_the_right = 0;
            int number_trees_encountered = 0;

            foreach (string entry in entries)
            {
                if (entry[steps_to_the_right % length_of_data_per_line] == '#')
                {
                    number_trees_encountered += 1;
                }

                steps_to_the_right += 3;
            }

            return number_trees_encountered;
        }
    }
}
