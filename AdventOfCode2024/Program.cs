using static AdventOfCode2024.Solutions.Day6.Utilities;

//1. Scan file and break into lines.
// var rows = GetRowsFromFileStringQuery(@"C:\Users\Charlie\RiderProjects\advent_of_code_24\AdventOfCode2024\Inputs\test6.txt");
var rows = GetRowsFromFileStringQuery(@"C:\Users\Charlie\RiderProjects\advent_of_code_24\AdventOfCode2024\Inputs\Day6.txt");

foreach (var row in rows)
{
    Console.WriteLine(row);
}

//2. Find starting line # and lineIndex of guard.
var initialLocation = GetInitialLocationQuery(rows);

Console.WriteLine(initialLocation);

//3. Go up until hit obstacle, counting steps as you go.
//4. Go right until hit obstacle, counting...
//5. Go down...
//6. Go left...
//7. Repeat until guard hits boundary of map (index == lines.Count || lines[row].Length)
//8. Return # of spots recorded.
int totalCount = GetTotalGuardMovementSumQuery(rows, initialLocation);

Console.WriteLine(totalCount);