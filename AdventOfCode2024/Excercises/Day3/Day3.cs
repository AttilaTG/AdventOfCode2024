using System.Text.RegularExpressions;

namespace AdventOfCode2024.Excercises.Day3
{
    public class Day3
    {
        private static string? LoadConfig()
        {
            string filepath = "filepath.txt";

            try
            {
                var lines = File.ReadAllLines(filepath);

                return String.Join("", lines); ;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        public static int Day3_1() 
        { 
            var input = LoadConfig();
            if (input is null) return 0;
            const string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";
            var matches = Regex.Matches(input, pattern, RegexOptions.Multiline);
            var result = matches
                .Cast<Match>()
                .Select(match =>
                {
                    var first = int.Parse(match.Groups[1].Value);
                    var second = int.Parse(match.Groups[2].Value);
                    return first * second;
                })
                .Sum();
            return result;
        }
    }
}
