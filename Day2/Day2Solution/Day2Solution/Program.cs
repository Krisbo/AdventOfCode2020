using System;
using System.Collections.Generic;

namespace Day2Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string filepath = "C:/Users/kristoffer.boe/krisbo_git/AdventOfCode2020/Day2/Day2Data.txt";

            string[] entries_string = System.IO.File.ReadAllLines(filepath);
            string[] valid_passwords_part1 = GetValidPasswordsPart1(entries_string);
            string[] valid_passwords_part2 = GetValidPasswordsPart2(entries_string);

            Console.WriteLine("password attempts: " + entries_string.Length.ToString());
            Console.WriteLine("passwords valid part 1: " + valid_passwords_part1.Length.ToString());
            Console.WriteLine("passwords valid part 1: " + valid_passwords_part2.Length.ToString());
        }

        public static string[] GetValidPasswordsPart1(string[] entries)
        {
            List<string> lst = new List<string>();
            foreach (string entry in entries)
            {
                int min = Convert.ToInt32(entry.Split('-')[0]);
                int max = Convert.ToInt32(entry.Split('-')[1].Split(' ')[0]);
                string character =entry.Split('-')[1].Split(' ')[1].Replace(':', ' ').Trim();
                string password = entry.Split('-')[1].Split(' ')[2].Trim();
                int numberOfAppearances = password.Length - password.Replace(character, "").Length;

                if(numberOfAppearances >= min & numberOfAppearances <= max)
                {
                    lst.Add(entry);
                    //Console.WriteLine("min: " + min.ToString() + ", max: " + max.ToString() + ", character: " + character.ToString() + ", numberOfApp.: " + numberOfAppearances + ", password: " + password);
                }
            }

            return lst.ToArray();
        }

        public static string[] GetValidPasswordsPart2(string[] entries)
        {
            List<string> lst = new List<string>();
            foreach (string entry in entries)
            {
                int index1 = Convert.ToInt32(entry.Split('-')[0])-1;
                if (index1 < 0) continue;
                int index2 = Convert.ToInt32(entry.Split('-')[1].Split(' ')[0])-1;

                string character = entry.Split('-')[1].Split(' ')[1].Replace(':', ' ').Trim();
                string password = entry.Split('-')[1].Split(' ')[2].Trim();

                if (password[index1] == Convert.ToChar(character) && password[index2] != Convert.ToChar(character)
                    || password[index1] != Convert.ToChar(character) && password[index2] == Convert.ToChar(character))
                {
                    lst.Add(entry);
                    //Console.WriteLine("index1: " + index1.ToString() + ", index2: " + index2.ToString() + ", character: " + character.ToString() + ", password: " + password);
                }
            }

            return lst.ToArray();
        }
    }
}
