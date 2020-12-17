using System;
using System.Text.RegularExpressions;

namespace Day4Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = "C:/Users/kristoffer.boe/krisbo_git/AdventOfCode2020/Day4/Day4Data.txt";
            string passports_string = System.IO.File.ReadAllText(filepath);

            string[] passports = passports_string.Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            int number_of_valid_passports_part_1 = CountValidPassportsPart1(passports);
            int number_of_valid_passports_part_2 = CountValidPassportsPart2(passports);

            Console.WriteLine("Number of valid passports part 1: "+ number_of_valid_passports_part_1.ToString());
            Console.WriteLine("Number of valid passports part 2: " + number_of_valid_passports_part_2.ToString());
        }

        private static int CountValidPassportsPart2(string[] passports)
        {
            int number_of_valid_passports = 0;

            foreach (string passport in passports)
            {
                string passport_lower = passport.ToLower();
                if (passport_lower.Contains("byr") &&
                    passport_lower.Contains("iyr") &&
                    passport_lower.Contains("eyr") &&
                    passport_lower.Contains("hgt") &&
                    passport_lower.Contains("hcl") &&
                    passport_lower.Contains("ecl") &&
                    passport_lower.Contains("pid"))
                {
                    string[] passport_splitted = passport_lower.Split(new string[] { " ", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    bool password_is_valid = true;
                    foreach(string entry in passport_splitted)
                    {
                        string[] entry_splitted = entry.Trim().Split(':');
                        if(entry_splitted[0] == "byr" && !(Convert.ToInt32(entry_splitted[1]) >= 1920 && Convert.ToInt32(entry_splitted[1]) <= 2002)) {
                            password_is_valid = false;
                            break;
                        }
                        if (entry_splitted[0] == "iyr" && !(Convert.ToInt32(entry_splitted[1]) >= 2010 && Convert.ToInt32(entry_splitted[1]) <= 2020))
                        {
                            password_is_valid = false;
                            break;
                        }
                        if (entry_splitted[0] == "eyr" && !(Convert.ToInt32(entry_splitted[1]) >= 2020 && Convert.ToInt32(entry_splitted[1]) <= 2030))
                        {
                            password_is_valid = false;
                            break;
                        }
                        if (entry_splitted[0] == "hgt" && 
                            !((entry_splitted[1].Contains("cm") 
                                && Convert.ToInt32(entry_splitted[1].Replace("cm", "")) >= 150 && Convert.ToInt32(entry_splitted[1].Replace("cm", "")) <= 193) || 
                             (entry_splitted[1].Contains("in")
                                && Convert.ToInt32(entry_splitted[1].Replace("in", "")) >= 59 && Convert.ToInt32(entry_splitted[1].Replace("in", "")) <= 76)))
                        {
                            password_is_valid = false;
                            break;
                        }
                        if (entry_splitted[0] == "hcl" && !(new Regex("^#[0-9a-f][0-9a-f][0-9a-f][0-9a-f][0-9a-f][0-9a-f]$").IsMatch(entry_splitted[1])))
                        {
                            password_is_valid = false;
                            break;
                        }
                        if (entry_splitted[0] == "ecl" && !(Array.Exists(new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }, element => element == entry_splitted[1])))
                        {
                            password_is_valid = false;
                            break;
                        }
                        if (entry_splitted[0] == "pid" && !(new Regex("^[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$").IsMatch(entry_splitted[1])))
                        {
                            password_is_valid = false;
                            break;
                        }
                    }

                    if (password_is_valid)
                    {
                        number_of_valid_passports += 1;
                    }
                }
            }

            return number_of_valid_passports;
        }

        private static int CountValidPassportsPart1(string[] passports)
        {
            int number_of_valid_passports = 0;

            foreach(string passport in passports)
            {
                string passport_lower = passport.ToLower();
                if (passport_lower.Contains("byr") &&
                    passport_lower.Contains("iyr") &&
                    passport_lower.Contains("eyr") &&
                    passport_lower.Contains("hgt") &&
                    passport_lower.Contains("hcl") &&
                    passport_lower.Contains("ecl") &&
                    passport_lower.Contains("pid"))
                {
                    number_of_valid_passports += 1;
                }
            }

            return number_of_valid_passports;
        } 
    }
}
