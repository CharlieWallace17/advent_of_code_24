using static AdventOfCode2024.Solutions.Day2.Utilities;

namespace AdventOfCode2024.Solutions.Day2;

public static class Results
{
    public static void GetDay2Part1Result()
    {
//1. Get List of strings from file.
        string[] strings = GetStringRowsFromFileQuery(@"C:\Users\Charlie\RiderProjects\advent_of_code_24\AdventOfCode2024\Inputs\Day2.txt");

//2. Convert strings into List<int>.
        var list = GetIntListsFromStringsQuery(strings);

//3. Check if all integers increasing == true || all integers decreasing == true.
//4. Check difference between adjacent integers is [1, 3].
//5. Sum total number of safe reports that meet above 2 criteria.
        int sumOfSafeRows = SumOfSafeRows(list);
        Console.WriteLine($"The sum of the safe rows: {sumOfSafeRows}");
    }

    public static void GetDay2Part2Result()
    {
//1. Get List of strings from file.
        string[] strings = GetStringRowsFromFileQuery(@"C:\Users\Charlie\RiderProjects\advent_of_code_24\AdventOfCode2024\Inputs\Day2.txt");

//2. Convert strings into List<int>.
        var list = GetIntListsFromStringsQuery(strings);

//3. Check if all integers increasing == true || all integers decreasing == true.
//4. Check difference between adjacent integers is [1, 3].
//5. Sum total number of safe reports that meet above 2 criteria.
        int sumOfSafeRows = SumOfSafeRowsWithoutBadLevel(list);

        Console.WriteLine($"The sum of the safe rows: {sumOfSafeRows}");
    }
}