namespace AdventOfCode2024.Solutions.Day5;

public static class Utilities
{
    public static List<List<string>> GetRulesFromFileStringQuery(string filePath)
    {
        string fileString = File.ReadAllText(filePath);

        var listOfStrings = fileString.Split('\n').ToList();

        return listOfStrings.Select(x => x.Split('|', StringSplitOptions.TrimEntries).ToList()).ToList();
    }

    public static List<List<string>> GetLinesFromFileStringQuery(string filePath)
    {
        string fileString = File.ReadAllText(filePath);

        var stringsWithCommas = fileString.Split('\n').ToList();

        return stringsWithCommas.Select(x => x.Split(',', StringSplitOptions.TrimEntries).ToList()).ToList();
    }

    private static bool CheckIfRuleAppliesQuery(List<string> rule, List<string> line)
    {
        return line.Contains(rule[0]) && line.Contains(rule[1]);
    }

    public static List<int> GetMedianIntFromValidLinesQuery(List<List<string>> rules, List<List<string>> lines)
    {
        var medianIntList = new List<int>();

        foreach (var line in lines)
        {
            bool lineIsValid = true;

            foreach (var rule in rules)
            {
                bool isRuleValid = CheckIfRuleAppliesQuery(rule, line);

                if (isRuleValid)
                {
                    int indexA = line.IndexOf(rule[0]);
                    int indexB = line.IndexOf(rule[1]);

                    if (indexA >= indexB)
                    {
                        lineIsValid = false;
                    }
                }
            }

            if (lineIsValid)
            {
                int middleIndex = line.Count / 2;

                int middleInt = int.Parse(line[middleIndex]);

                medianIntList.Add(middleInt);
            }
        }

        return medianIntList;
    }

    public static List<int> GetMedianIntFromInvalidLinesQuery(List<List<string>> rules, List<List<string>> lines)
    {
        var medianIntList = new List<int>();

        foreach (var line in lines)
        {
            bool lineIsInvalid = false;

            var placeHolderLine = line;

            for (int i = 0; i < rules.Count; i++)
            {
                var rule = rules[i];

                bool isRuleValid = CheckIfRuleAppliesQuery(rule, line);

                if (isRuleValid)
                {
                    int indexA = line.IndexOf(rule[0]);
                    int indexB = line.IndexOf(rule[1]);

                    if (indexA >= indexB)
                    {
                        lineIsInvalid = true;

                        while (indexA >= indexB)
                        {
                            placeHolderLine = MoveItemBackOneIndexCommand(line, indexA);
                            indexA = placeHolderLine.IndexOf(rule[0]);
                            indexB = placeHolderLine.IndexOf(rule[1]);
                        }

                        i = 0;
                    }
                }
            }

            if (lineIsInvalid)
            {
                int middleIndex = placeHolderLine.Count / 2;

                int middleInt = int.Parse(placeHolderLine[middleIndex]);

                medianIntList.Add(middleInt);
            }
        }

        return medianIntList;
    }

    private static List<string> MoveItemBackOneIndexCommand(this List<string> line, int index)
    {
        (line[index - 1], line[index]) = (line[index], line[index - 1]);

        return line;
    }
}