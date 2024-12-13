using static AdventOfCode2024.Solutions.Day3.Utilities;

namespace AdventOfCode2024.Solutions.Day3;

public static class Results
{
    public static void GetDay3Part1Result()
    {
//1. Find all matching instances and add to list.
        List<string> list = GetValidOpsFromFileStringQuery(@"C:\Users\Charlie\RiderProjects\advent_of_code_24\AdventOfCode2024\Inputs\Day3.txt");

//2. Split list into number pairs.
        var numList = GetValidNumbersFromStringsQuery(list);

//3. Multiply number pairs and add result to new list.
        var multNumList = GetMultValueFromNumbersQuery(numList);

//4. Sum number list for total.
        Console.WriteLine(multNumList.Sum());
    }

    public static void GetDay3Part2Result()
    {
//1. Find all matching instances and add to list.
        List<string> list = GetValidOpsPlusConditionalsFromFileStringQuery(@"C:\Users\Charlie\RiderProjects\advent_of_code_24\AdventOfCode2024\Inputs\Day3.txt");

//2. Split list into number pairs.
        var numList = GetValidNumbersFromStringsMinusConditionalsQuery(list);

//3. Multiply number pairs and add result to new list.
        var multNumList = GetMultValueFromNumbersQuery(numList);

//4. Sum number list for total.
        Console.WriteLine(multNumList.Sum());
    }
}