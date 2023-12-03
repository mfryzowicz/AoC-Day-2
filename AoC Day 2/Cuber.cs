namespace AoC_Day_2;

public class Cuber
{
    private string _red = "red";
    private string _green = "green";
    private string _blue = "blue";
    private static int _redRequired = 12;
    private static int _greenRequired = 13;
    private static int _blueRequired = 14;
    private int _totalAllowed = _redRequired + _greenRequired + _blueRequired;
    
    public async Task<int> MinCubeChecker(List<string> input)
    {
        var counter = 0;

        var sum = 0;
        List<int> powers = new();
        
        foreach (var game in input)
        {
            var minRed = 0;
            var minGreen = 0;
            var minBlue = 0;
            
            var gameSplits = game.Split(":").ToList();
            
            var subGamesString = gameSplits.Last();
            var subGames = subGamesString.Split(";").ToList();

            foreach (var subGameString in subGames)
            {
                var cubes = subGameString.Split(",").ToList();
                var trimmedCubes = cubes.Select(s=>s.Trim()).ToList();
                
                foreach (var cube in trimmedCubes)
                {
                    if (cube.Contains(_red))
                    {
                        var cubeAmount = await CubeCounter(cube);
                        if (cubeAmount > minRed)
                        {
                            minRed = cubeAmount;
                        }
                    }
                
                    if (cube.Contains(_green))
                    {
                        var cubeAmount = await CubeCounter(cube);
                        
                        if (cubeAmount > minGreen)
                        {
                            minGreen = cubeAmount;
                        }
                    }
                
                    if (cube.Contains(_blue))
                    {
                        var cubeAmount = await CubeCounter(cube);
                        
                        if (cubeAmount > minBlue)
                        {
                            minBlue = cubeAmount;
                        }
                    }
                }
            }
            
            powers.Add(minRed * minGreen * minBlue);
        }

        sum = powers.Sum();

        Console.WriteLine(sum);

        return sum;
    }
    
    public async Task<int> PossibilityChecker(List<string> input)
    {
        var gameCalc = 0;
        var counter = 0;
        
        foreach (var game in input)
        {
            var isImpossible = false;
            
            var gameNum = 0;

            var gameSplits = game.Split(":").ToList();

            var gameString = gameSplits.First();
            
            if (gameString.Length == 6)
            {
                var tempNum = int.Parse(gameString.Substring(5));
                gameNum = tempNum;
            }
                    
            if (gameString.Length == 7)
            {
                var tempNum = int.Parse(gameString.Substring(5, 2));
                gameNum = tempNum;
            }
                    
            if (gameString.Length == 8)
            {
                var tempNum = int.Parse(gameString.Substring(5, 3));
                gameNum = tempNum;
            }
            
            var subGamesString = gameSplits.Last();
            var subGames = subGamesString.Split(";").ToList();

            foreach (var subGameString in subGames)
            {
                var cubes = subGameString.Split(",").ToList();
                var trimmedCubes = cubes.Select(s=>s.Trim()).ToList();
                
                foreach (var cube in trimmedCubes)
                {
                    List<int> reds = new();
                    List<int> greens = new();
                    List<int> blues = new();
                    var totalCubes = 0;
                    
                    if (cube.Contains(_red))
                    {
                        var cubeAmount = await CubeCounter(cube);
                    
                        reds.Add(cubeAmount);
                    }
                
                    if (cube.Contains(_green))
                    {
                        var cubeAmount = await CubeCounter(cube);
                    
                        greens.Add(cubeAmount);
                    }
                
                    if (cube.Contains(_blue))
                    {
                        var cubeAmount = await CubeCounter(cube);
                    
                        blues.Add(cubeAmount);
                    }
                    
                    totalCubes = reds.Sum() + greens.Sum() + blues.Sum();

                    if (totalCubes > _totalAllowed || reds.Sum() > _redRequired || greens.Sum() > _greenRequired || blues.Sum()> _blueRequired)
                    {
                        isImpossible = true;
                    }
                }
            }

            if (isImpossible)
            {
                counter++;
                continue;
            }
            
            gameCalc = gameCalc + gameNum;
        }

        Console.WriteLine(gameCalc);

        return gameCalc;
    }

    private async Task<int> CubeCounter(string cube)
    {
        string tempNum;

        tempNum = cube.Substring(0, 1);
        if (char.IsDigit(char.Parse(cube.Substring(1, 1))))
        {
            tempNum = tempNum + cube.Substring(1, 1);

            if (char.IsDigit(char.Parse(cube.Substring(2, 1))))
            {
                tempNum = tempNum + cube.Substring(2, 1);
            }
        }

        return int.Parse(tempNum);
    }
}