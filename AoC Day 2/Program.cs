// See https://aka.ms/new-console-template for more information

using AoC_Day_2;

Console.WriteLine("Starting game!");

List<string> testData = new()
{
    "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
    "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
    "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
    "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
    "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
};

Cuber cuber = new();

var input = File.ReadAllLines(
    "/Users/mfryzowicz/Documents/Repos/AdventOfCode/Day2/AoC Day 2/AoC Day 2/input.txt").ToList();

// await cuber.PossibilityChecker(input);
await cuber.MinCubeChecker(input);

Console.WriteLine("Ending game!");