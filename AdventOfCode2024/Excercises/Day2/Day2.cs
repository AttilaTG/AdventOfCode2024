using System.Reflection.Metadata.Ecma335;

namespace AdventOfCode2024.Excercises.Day2
{
    public class Day2
    {
        private static List<List<int>>? LoadConfig() 
        {
            string filepath = "filepath.txt";

            try
            {
                var lines = File.ReadAllLines(filepath);
                var outerList = lines
                    .Select(line => line
                        .Split(" ")
                        .Select(int.Parse)
                        .ToList())
                    .ToList();

                return outerList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }
        public static int Day2_1() 
        {
            var input = LoadConfig();
            if (input is not null) 
            {
                var result = input
                    .Select(row => 
                    {
                        var isAscending = row.Zip(row.Skip(1), (first, second) => first < second).All(result => result);
                        var isDescending = row.Zip(row.Skip(1), (first, second) => first > second).All(result => result);
                        if (isAscending || isDescending) 
                        {
                            var isSafe = !row.Zip(row.Skip(1), (first, second) => Math.Abs(second - first)).Any(x => x > 3 || x <= 0);
                            return isSafe;
                        }
                        return false;
                    })
                    .Count(x=> x is true);
                
                return result;
            }
            return 0;
        }
    }
}
