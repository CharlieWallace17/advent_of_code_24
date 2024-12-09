namespace AdventOfCode2024.Solutions.Day1;

public static class Utilities
{
    public class BisectArrayToListsQueryResult
    {
        public List<int> ListA { get; } = [];
        public List<int> ListB { get; } = [];
    }

    public static int[] GetNumbersFromFileQuery(string fileInput)
    {
        string contents = File.ReadAllText(fileInput);

        string[] lines = contents.Split(["\r\n", "\r", "\n", "   "], StringSplitOptions.None);

        return lines.Select(int.Parse).ToArray();
    }

    public static BisectArrayToListsQueryResult BisectArrayToListsQuery(int[] intArray)
    {
        var listContainer = new BisectArrayToListsQueryResult();

        for (int i = 0; i < intArray.Length; i++)
        {
            if (i % 2 == 0)
                listContainer.ListB.Add(intArray[i]);
            else
                listContainer.ListA.Add(intArray[i]);
        }

        return listContainer;
    }

    public static BisectArrayToListsQueryResult GetSortedListsByValueQuery(BisectArrayToListsQueryResult listContainer)
    {
        listContainer.ListA.Sort();

        listContainer.ListB.Sort();

        return listContainer;
    }

    public static List<int> GetAbsDistanceBetweenListsQuery(BisectArrayToListsQueryResult listContainer)
    {
        var absDistanceList = new List<int>();

        for (int i = 0; i < listContainer.ListA.Count; i++)
        {
            int distance = Math.Abs(listContainer.ListA[i] - listContainer.ListB[i]);

            absDistanceList.Add(distance);
        }

        return absDistanceList;
    }

    public static int GetTotalQuery(List<int> numbers)
    {
        return numbers.Sum();
    }

    public static List<int> GetCountOfListAInListBQuery(BisectArrayToListsQueryResult listContainer)
    {
        var frequencyList = new List<int>();

        foreach (int num in listContainer.ListA)
        {
            int count = listContainer.ListB.Count(i => i == num);

            frequencyList.Add(count);
        }

        return frequencyList;
    }

    public static List<int> MultiplyListsQuery(List<int> list1, List<int> list2)
    {
        return list1.Zip(list2, (l1, l2) => l1 * l2).ToList();
    }
}