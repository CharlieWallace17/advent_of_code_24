using System.Text.RegularExpressions;

namespace AdventOfCode2024.Solutions.Day3;

public static class Utilities
{
    public static List<string> GetValidOpsFromFileString(string filePath)
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
}