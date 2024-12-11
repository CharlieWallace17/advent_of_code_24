using System.Text.RegularExpressions;

namespace AdventOfCode2024.Solutions.Day3;

public static class Utilities
{
    public static List<string> GetValidOpsFromFileStringQuery(string filePath)
    {
        string fileString = File.ReadAllText(filePath);

        var matchCollection = Regex.Matches(fileString, @"mul\([0-9]{0,3},[0-9]{0,3}\)");

        var matchList = new List<string>();

        foreach (object match in matchCollection)
        {
            if (match is not null)
                matchList.Add(match.ToString());
        }

        return matchList;
    }

    public static List<List<int>> GetValidNumbersFromStringsQuery(List<string> fileLines)
    {
        var numList = new List<List<int>>();

        foreach (string line in fileLines)
        {
            var numLine = line.Trim().Split(["mul(", ",", ")"], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            numList.Add(numLine);
        }

        return numList;
    }

    public static List<int> GetMultValueFromNumbersQuery(List<List<int>> fileLines)
    {
        var multNumList = fileLines.Select(x => x[0] * x[1]).ToList();

        return multNumList;
    }
}