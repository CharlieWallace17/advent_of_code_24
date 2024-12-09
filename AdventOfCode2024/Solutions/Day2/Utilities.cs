namespace AdventOfCode2024.Solutions.Day2;

public static class Utilities
{
    public static string[] GetStringRowsFromFileQuery(string fileInput)
    {
        string contents = File.ReadAllText(fileInput);

        string[] lines = contents.Split(["\r\n", "\r", "\n"], StringSplitOptions.None);

        return lines;
    }

    public static List<List<int>> GetIntListsFromStringsQuery(string[] lines)
    {
        var masterList = new List<List<int>>();

        foreach (string line in lines)
        {
            string[] stringNums = line.Split([" "], StringSplitOptions.None);

            var childList = stringNums.Select(int.Parse).ToList();

            masterList.Add(childList);
        }

        return masterList;
    }

    private static bool ConstantIncreaseOrDecreaseQuery(List<int> numList)
    {
        bool result = true;

        //Check if only decreasing.
        for (int i = 0; i < numList.Count; i++)
        {
            if (i + 1 >= numList.Count)
                break;

            if (numList[i] <= numList[i + 1])
            {
                result = false;
                break;
            }
        }

        if (!result)
        {
            //Check if only increasing.
            for (int i = 0; i < numList.Count; i++)
            {
                if (i + 1 >= numList.Count)
                {
                    result = true;
                    break;
                }

                if (numList[i] >= numList[i + 1])
                    break;
            }
        }

        return result;
    }

    private static bool IsDiffInRangeQuery(List<int> numList)
    {
        bool result = true;

        for (int i = 0; i < numList.Count; i++)
        {
            if (i + 1 >= numList.Count)
                break;

            if (Math.Abs(numList[i] - numList[i + 1]) < 1 || Math.Abs(numList[i] - numList[i + 1]) > 3)
            {
                result = false;
                break;
            }
        }

        return result;
    }

    public static int SumOfSafeRows(List<List<int>> masterList)
    {
        int sum = 0;

        foreach (var childList in masterList)
        {
            bool isConstantIncreaseOrDecrease = ConstantIncreaseOrDecreaseQuery(childList);
            bool isDiffInRange = IsDiffInRangeQuery(childList);

            if (isConstantIncreaseOrDecrease && isDiffInRange)
                sum++;
        }

        return sum;
    }

    public static int SumOfSafeRowsWithoutBadLevel(List<List<int>> masterList)
    {
        int sum = 0;

        foreach (var childList in masterList)
        {
            for (int i = 0; i < childList.Count; i++)
            {
                var newList = new List<int>(childList);

                newList.RemoveAt(i);

                bool isConstantIncreaseOrDecrease = ConstantIncreaseOrDecreaseQuery(newList);
                bool isDiffInRange = IsDiffInRangeQuery(newList);

                if (isConstantIncreaseOrDecrease && isDiffInRange)
                {
                    sum++;
                    break;
                }
            }
        }

        return sum;
    }
}