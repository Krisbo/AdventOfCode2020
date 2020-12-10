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

            int number_of_trees_encountered_part_1 = getNumberOfEncounteredTreesOnlyPartOne(entries);
            Console.WriteLine("Number of trees part 1: " + number_of_trees_encountered_part_1);

            long number_of_trees_encountered_part_2_11 = getNumberOfEncounteredTrees(entries, 1, 1);
            long number_of_trees_encountered_part_2_31 = getNumberOfEncounteredTrees(entries, 3, 1);
            long number_of_trees_encountered_part_2_51 = getNumberOfEncounteredTrees(entries, 5, 1);
            long number_of_trees_encountered_part_2_71 = getNumberOfEncounteredTrees(entries, 7, 1);
            long number_of_trees_encountered_part_2_12 = getNumberOfEncounteredTrees(entries, 1, 2);

            long number_of_trees_encountered_part_2_multiplied = number_of_trees_encountered_part_2_11 
                    * number_of_trees_encountered_part_2_31
                    * number_of_trees_encountered_part_2_51 
                    * number_of_trees_encountered_part_2_71 
                    * number_of_trees_encountered_part_2_12;

            Console.WriteLine("Number of trees 1 1: " + number_of_trees_encountered_part_2_11);
            Console.WriteLine("Number of trees 3 1: " + number_of_trees_encountered_part_2_31);
            Console.WriteLine("Number of trees 5 1: " + number_of_trees_encountered_part_2_51);
            Console.WriteLine("Number of trees 7 1: " + number_of_trees_encountered_part_2_71);
            Console.WriteLine("Number of trees 1 2: " + number_of_trees_encountered_part_2_12);
            Console.WriteLine("Number of trees multiplied: " + number_of_trees_encountered_part_2_multiplied);
        }

        private static int getNumberOfEncounteredTrees(string[] entries, int steps_to_the_right, int steps_down)
        {
            int length_of_data_per_line = entries[0].Length;
            int right_position = 0;
            int number_trees_encountered = 0;

            for(int i = 0; i < entries.Length; i += steps_down)
            {
                if (entries[i][right_position % length_of_data_per_line] == '#')
                {
                    number_trees_encountered += 1;
                }

                right_position += steps_to_the_right;
            }

            return number_trees_encountered;
        }

        private static int getNumberOfEncounteredTreesOnlyPartOne(string[] entries)
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
