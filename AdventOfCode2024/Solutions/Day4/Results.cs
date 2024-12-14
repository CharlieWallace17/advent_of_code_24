using static AdventOfCode2024.Solutions.Day4.Utilities;

namespace AdventOfCode2024.Solutions.Day4;

public static class Results
{
    public static void GetDay4Part1Result()
    {
//1. Get rows from file string.
        var rows = GetRowsFromFileStringQuery(@"C:\Users\Charlie\RiderProjects\advent_of_code_24\AdventOfCode2024\Inputs\Day4.txt");

//2. Get horizontal instances count (fwd & bwd).
        int horizontalCount = GetHorizontalCountQuery(rows);

//3. Get vertical instances count (fwd & bwd).
        int verticalCount = GetVerticalCountQuery(rows);

//4. Get diagonal instances count (TL-BR, TR-BL).
        int diagonalCount = GetDiagonalCountQuery(rows);

//5. Sum total instances.
        int totalInstances = horizontalCount + verticalCount + diagonalCount;
        Console.WriteLine($"Total: {totalInstances}");
    }

    public static void GetDay4Part2Result()
    {
//1. Get rows from file string.
        var rows = GetRowsFromFileStringQuery(@"C:\Users\Charlie\RiderProjects\advent_of_code_24\AdventOfCode2024\Inputs\Day4.txt");

//4. Get diagonal instances count (TL-BR, TR-BL).
        int xmasCount = GetXmasCountQuery(rows);

//5. Sum total instances.
        Console.WriteLine($"Total: {xmasCount}");
    }
}