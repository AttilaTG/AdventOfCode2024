namespace AdventOfCode2024.Excercises.Day1
{
    public  class Day1
    {

        private static (IEnumerable<int>? ColA, IEnumerable<int>? ColB) LoadValues()
        {
            string filepath = "filepath.txt";
            try
            {
                var lines = File.ReadAllLines(filepath);
                var colA = new List<int>();
                var colB = new List<int>();

                foreach (var item in lines)
                {
                    var cols = item.Split("   ");
                    colA.Add(Int32.Parse(cols[0]));
                    colB.Add(Int32.Parse(cols[1]));
                }

                colA.Sort();
                colB.Sort();

                return (colA, colB);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (null, null);
            }
        }

        public static int Day1_1() 
        {
            var (colA, colB) = LoadValues();
            if (colA is not null && colB is not null) 
            {
                var result = colA.Zip(colB, (a, b) => Math.Abs(a - b)).Sum();
                return result;
            }
            return 0;
        }

        public static int Day1_2() 
        {
            var (colA, colB) = LoadValues();
            if (colA is not null && colB is not null)
            {
                var result = colA.Zip(colB, (a, b) => a * colB.Count(x => x.Equals(a))).Sum();
                return result;
            }
            return 0;
        }
    }
}
