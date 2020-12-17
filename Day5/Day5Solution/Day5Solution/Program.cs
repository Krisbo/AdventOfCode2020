using System;
using System.Collections.Generic;

namespace Day5Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(GetSeatRow("FBFBBFF"));
            //Console.WriteLine(GetSeatColumn("RLR"));

            //Console.WriteLine(GetSeatNumber("BFFFBBFRRR"));
            //Console.WriteLine(GetSeatNumber("FFFBBBFRRR"));
            //Console.WriteLine(GetSeatNumber("BBFFBBFRLL"));

            string filepath = "C:/Users/kristoffer.boe/krisbo_git/AdventOfCode2020/Day5/Day5Data.txt";
            string[] flight_seats = System.IO.File.ReadAllLines(filepath);

            int highest_seat_id = 0;
            List<int> seats = new List<int>();

            foreach(string flight_seat in flight_seats)
            {
                int current_seat_id = GetSeatNumber(flight_seat);
                seats.Add(current_seat_id);
                if (current_seat_id > highest_seat_id)
                {
                    highest_seat_id = current_seat_id;
                }
            }
            
            Console.WriteLine("Highest seat ID in dataset: " + highest_seat_id.ToString());
            seats.Sort();

            int[] steats_array = seats.ToArray();

            Console.WriteLine("My seat ID is: " + GetMissingSeat(steats_array).ToString());
        }

        private static int GetMissingSeat(int[] steats_array)
        {
            for (int i = 0; i < steats_array.Length - 1; i++)
            {
                if (steats_array[i] + 2 == steats_array[i + 1])
                {
                    return steats_array[i] + 1;
                }
            }
            return -1;
        }

        private static int GetSeatNumber(string binary_space_partitioning)
        {
            string row_binary_space_partitioning = binary_space_partitioning.Substring(0, 7);
            string column_binary_space_partitioning = binary_space_partitioning.Substring(7, 3);

            int row = GetSeatRow(row_binary_space_partitioning);
            int column = GetSeatColumn(column_binary_space_partitioning);

            int seat_id = row * 8 + column;

            //Console.WriteLine(binary_space_partitioning + ": row " + row.ToString() + ", column " + column.ToString() + ", seat ID " + seat_id);

            return seat_id;
        }

        private static int GetSeatRow(string row, int row_range_min = 0, int row_range_max = 127)
        {
            //Console.WriteLine("row: " + row + ", row_range_min: " + row_range_min.ToString() + ", row_range_max: " + row_range_max.ToString());
            if (row.Length == 0)
            {
                return row_range_min;
            }
            if (row[0] == 'F')
            {
                return GetSeatRow(row.Remove(0, 1), row_range_min, Convert.ToInt32(Math.Floor(Convert.ToDouble(row_range_min) + ((Convert.ToDouble(row_range_max) - Convert.ToDouble(row_range_min)) / 2))));
            }
            if (row[0] == 'B')
            {
                return GetSeatRow(row.Remove(0, 1), Convert.ToInt32(Math.Ceiling(Convert.ToDouble(row_range_min) + ((Convert.ToDouble(row_range_max) - Convert.ToDouble(row_range_min)) / 2))), row_range_max);
            }
            return row_range_min;
        }

        private static int GetSeatColumn(string column, int column_range_min = 0, int column_range_max = 7)
        {
            //Console.WriteLine("column: " + column + ", column_range_min: " + column_range_min.ToString() + ", column_range_max: " + column_range_max.ToString());
            if (column.Length == 0)
            {
                return column_range_min;
            }
            
            if (column[0] == 'L')
            {
                return GetSeatColumn(column.Remove(0, 1), column_range_min, Convert.ToInt32(Math.Floor(Convert.ToDouble(column_range_min) + ((Convert.ToDouble(column_range_max) - Convert.ToDouble(column_range_min)) / 2))));
            }
            if (column[0] == 'R')
            {
                return GetSeatColumn(column.Remove(0, 1), Convert.ToInt32(Math.Ceiling(Convert.ToDouble(column_range_min) + ((Convert.ToDouble(column_range_max) - Convert.ToDouble(column_range_min)) / 2))), column_range_max);
            }
            return column_range_min;
        }
    }
}
