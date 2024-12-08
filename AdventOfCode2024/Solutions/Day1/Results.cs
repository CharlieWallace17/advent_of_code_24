using static AdventOfCode2024.Solutions.Day1.Utilities;

namespace AdventOfCode2024.Solutions.Day1;

public static class Results
{
    public static void GetDay1Part1Result()
    {
//1. Read integer values from file.
        int[] numbers = GetNumbersFromFileQuery(@"C:\Users\Charlie\RiderProjects\AdventOfCode2024\AdventOfCode2024\Inputs\Day1.txt");

//2. Separate values into 2 lists, based on index.
        var listObject = BisectArrayToListsQuery(numbers);

//3. Sort lists in ascending numerical value.
        var sortedListObject = GetSortedListsByValueQuery(listObject);

//4. Get List<int> of absolute value distances between lists.
        var distanceList = GetAbsDistanceBetweenListsQuery(sortedListObject);

//5. Sum array values for total value.
        int totalDistance = GetTotalQuery(distanceList);

        Console.WriteLine(totalDistance);
    }

    public static void GetDay1Part2Result()
    {
//1. Read integer values from file.
        int[] numbers = GetNumbersFromFileQuery(@"C:\Users\Charlie\RiderProjects\advent_of_code_24\AdventOfCode2024\Inputs\Day1.txt");

//2. Separate values into 2 lists, based on index.
        var listObject = BisectArrayToListsQuery(numbers);

//3. For each number in ListA, search # of instances in ListB. Add this # to new List<int>.
        var countList = GetCountOfListAInListBQuery(listObject);

//4. Multiply ListA by frequency List;
        var multList = MultiplyListsQuery(listObject.ListA, countList);

//5. Sum the results in the multiplied list for total score.
        int total = GetTotalQuery(multList);

        Console.WriteLine(total);
    }
}