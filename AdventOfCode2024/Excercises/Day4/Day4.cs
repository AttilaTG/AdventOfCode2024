namespace AdventOfCode2024.Excercises.Day4
{
    
    public class Day4
    {
        private static string[]? LoadConfig()
        {
            string filepath = "Day4_Input.txt";

            try
            {
                var lines = File.ReadAllLines(filepath);
                return lines; 
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        public static int Day4_1()
        {
            var input = LoadConfig();
            if (input is null) return 0;
            var xmasCounter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                var canReadDown = i + 4 <= input.Length;
                var canReadUp = i - 3 >= 0;
                for (int j = 0; j < input[i].Length; j++)
                {
                    var canReadLtoR = j + 4 <= input[i].Length;
                    var canReadRtoL = j - 3 >= 0;
                    if (input[i][j].Equals('X'))
                    {
                        if (canReadLtoR)
                        {
                            var possibleM = input[i][j + 1];
                            var possibleA = input[i][j + 2];
                            var possibleS = input[i][j + 3];
                            if (possibleM.Equals('M') && possibleA.Equals('A') && possibleS.Equals('S'))
                            {
                                xmasCounter++;
                            }
                        }

                        if (canReadRtoL)
                        {
                            var possibleM = input[i][j - 1];
                            var possibleA = input[i][j - 2];
                            var possibleS = input[i][j - 3];
                            if (possibleM.Equals('M') && possibleA.Equals('A') && possibleS.Equals('S'))
                            {
                                xmasCounter++;
                            }
                        }

                        if (canReadUp)
                        {
                            var possibleM = input[i - 1][j];
                            var possibleA = input[i - 2][j];
                            var possibleS = input[i - 3][j];
                            if (possibleM.Equals('M') && possibleA.Equals('A') && possibleS.Equals('S'))
                            {
                                xmasCounter++;
                            }
                        }

                        if (canReadDown)
                        {
                            var possibleM = input[i + 1][j];
                            var possibleA = input[i + 2][j];
                            var possibleS = input[i + 3][j];
                            if (possibleM.Equals('M') && possibleA.Equals('A') && possibleS.Equals('S'))
                            {
                                xmasCounter++;
                            }
                        }

                        var diagonalLtoRUp = canReadUp && canReadLtoR;
                        var diagonalRtoLUp = canReadUp && canReadRtoL;
                        var diagonalLtoRDown = canReadDown && canReadLtoR;
                        var diagonalRtoLDown = canReadDown && canReadRtoL;

                        if (diagonalLtoRUp)
                        {
                            var possibleM = input[i - 1][j + 1];
                            var possibleA = input[i - 2][j + 2];
                            var possibleS = input[i - 3][j + 3];
                            if (possibleM.Equals('M') && possibleA.Equals('A') && possibleS.Equals('S'))
                            {
                                xmasCounter++;
                            }
                        }

                        if (diagonalRtoLUp)
                        {
                            var possibleM = input[i - 1][j - 1];
                            var possibleA = input[i - 2][j - 2];
                            var possibleS = input[i - 3][j - 3];
                            if (possibleM.Equals('M') && possibleA.Equals('A') && possibleS.Equals('S'))
                            {
                                xmasCounter++;
                            }
                        }

                        if (diagonalLtoRDown)
                        {
                            var possibleM = input[i + 1][j + 1];
                            var possibleA = input[i + 2][j + 2];
                            var possibleS = input[i + 3][j + 3];
                            if (possibleM.Equals('M') && possibleA.Equals('A') && possibleS.Equals('S'))
                            {
                                xmasCounter++;
                            }
                        }

                        if (diagonalRtoLDown)
                        {
                            var possibleM = input[i + 1][j - 1];
                            var possibleA = input[i + 2][j - 2];
                            var possibleS = input[i + 3][j - 3];
                            if (possibleM.Equals('M') && possibleA.Equals('A') && possibleS.Equals('S'))
                            {
                                xmasCounter++;
                            }
                        }
                    }
                }
            }
            return xmasCounter;
        }
        public static int Day4_2() 
        {
            var input = LoadConfig();
            if (input is null) return 0;
            var xmasCounter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                var canReadDown = i + 1 < input.Length;
                var canReadUp = i - 1 >= 0;
                for (int j = 0; j < input[i].Length; j++)
                {
                    var canReadLtoR = j + 1 < input[i].Length;
                    var canReadRtoL = j - 1 >= 0;
                    if (input[i][j].Equals('A'))
                    {
                        var diagonalLtoRUp = canReadUp && canReadLtoR;
                        var diagonalRtoLUp = canReadUp && canReadRtoL;
                        var diagonalLtoRDown = canReadDown && canReadLtoR;
                        var diagonalRtoLDown = canReadDown && canReadRtoL;

                        if (diagonalLtoRUp && diagonalLtoRDown && diagonalRtoLUp && diagonalRtoLDown) 
                        {
                            var upLeft = input[i - 1][j - 1]; 
                            var upRight = input[i - 1][j + 1];
                            var downLeft = input[i + 1][j - 1];
                            var downRight = input[i + 1][j + 1];

                            var a = new List<char>{ upLeft, upRight, downLeft, downRight };

                            var hasInvalidChars = a.Any(x => x.Equals('A') || x.Equals('X'));
                            
                            if ((upLeft != downRight)&&(upRight != downLeft)&&!hasInvalidChars)
                            {
                                xmasCounter++;
                            }
                        }
                    }
                }
            }
            return xmasCounter;
        }
    }
}
