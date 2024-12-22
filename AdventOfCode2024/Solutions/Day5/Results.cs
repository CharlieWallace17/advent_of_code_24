using static AdventOfCode2024.Solutions.Day5.Utilities;

namespace AdventOfCode2024.Solutions.Day5;

public static class Results
{
    public static void GetDay5Part1Result()
    {
//1. Get rule List<List<string>>
//2. Get line List<List<string>>
        var rules = GetRulesFromFileStringQuery(@"C:\Users\Charlie\RiderProjects\advent_of_code_24\AdventOfCode2024\Inputs\Day5.1.txt");
        var lines = GetLinesFromFileStringQuery(@"C:\Users\Charlie\RiderProjects\advent_of_code_24\AdventOfCode2024\Inputs\Day5.2.txt");

//3. For each rule, check if both in that line.
//4. If no, skip. If yes, get index of each & check if index(x1) < index(x2)
//5. If yes, get median # string between those indices & add to sum List<string>
//6. Sum up List<string> after parsing to int.
        var total = GetMedianIntFromValidLinesQuery(rules, lines);
        Console.WriteLine(total.Sum());
    }

    public static void GetDay5Part2Result()
    {
//1. Get rule List<List<string>>
//2. Get line List<List<string>>
        var rules = GetRulesFromFileStringQuery(@"C:\Users\Charlie\RiderProjects\advent_of_code_24\AdventOfCode2024\Inputs\Day5.1.txt");
        var lines = GetLinesFromFileStringQuery(@"C:\Users\Charlie\RiderProjects\advent_of_code_24\AdventOfCode2024\Inputs\Day5.2.txt");

//3. For each rule, check if both in that line.
//4. If no, skip. If yes, get index of each & check if index(x1) < index(x2)
//5. If no, mark rule as "relevant" and move x1 a single index back until comes before x2. Then, get median # string between those indices & add to sum List<string>
//6. Sum up List<string> after parsing to int.
        var total = GetMedianIntFromInvalidLinesQuery(rules, lines);
        Console.WriteLine(total.Sum());
    }
}