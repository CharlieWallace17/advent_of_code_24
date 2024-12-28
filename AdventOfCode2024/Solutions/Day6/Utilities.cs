namespace AdventOfCode2024.Solutions.Day6;

public static class Utilities
{
    public static List<List<char>> GetRowsFromFileStringQuery(string filePath)
    {
        string fileString = File.ReadAllText(filePath);

        var listOfStrings = fileString.Split('\n').ToList();

        return listOfStrings.Select(x => x.ToList()).ToList();
    }

    public static (int lineNum, int rowNum) GetInitialLocationQuery(List<List<char>> rows)
    {
        int? lineNumber = null;
        int? rowIndex = null;

        foreach (var row in rows)
        {
            foreach (char c in row.Where(c => c == '^'))
            {
                rowIndex = row.IndexOf(c);
                break;
            }

            if (rowIndex == null) continue;
            lineNumber = rows.IndexOf(row);
            break;
        }

        return (lineNumber!.Value, rowIndex!.Value);
    }

    public enum NextDirection
    {
        Up,
        Right,
        Down,
        Left,
        Break
    }

    public class GuardMovementResult
    {
        public List<List<char>>? MarkedRows { get; set; }
        public (int lineNum, int rowIndex) CurrentLocation { get; set; }
        public NextDirection NextDirection { get; set; }
    }

    public static GuardMovementResult GetGuardMovementUpQuery(List<List<char>> rows, (int lineNum, int rowIndex) location)
    {
        var muteableRows = rows;

        while (location.lineNum - 1 >= 0 && rows[location.lineNum - 1][location.rowIndex] != '#')
        {
            muteableRows[location.lineNum][location.rowIndex] = 'X';
            location = (location.lineNum - 1, location.rowIndex);
        }

        return new GuardMovementResult
        {
            MarkedRows = muteableRows,
            CurrentLocation = location,
            NextDirection = location.lineNum - 1 >= 0 ? NextDirection.Right : NextDirection.Break
        };
    }

    public static GuardMovementResult GetGuardMovementRightQuery(List<List<char>> rows, (int lineNum, int rowIndex) location)
    {
        var muteableRows = rows;

        while (location.rowIndex + 1 < rows[location.lineNum].Count && rows[location.lineNum][location.rowIndex + 1] != '#')
        {
            muteableRows[location.lineNum][location.rowIndex] = 'X';
            location = (location.lineNum, location.rowIndex + 1);
        }

        return new GuardMovementResult
        {
            MarkedRows = muteableRows,
            CurrentLocation = location,
            NextDirection = location.rowIndex + 1 < rows[location.lineNum].Count ? NextDirection.Down : NextDirection.Break
        };
    }

    public static GuardMovementResult GetGuardMovementDownQuery(List<List<char>> rows, (int lineNum, int rowIndex) location)
    {
        while (location.lineNum + 1 < rows.Count && rows[location.lineNum + 1][location.rowIndex] != '#')
        {
            rows[location.lineNum][location.rowIndex] = 'X';
            location = (location.lineNum + 1, location.rowIndex);
        }

        return new GuardMovementResult
        {
            MarkedRows = rows,
            CurrentLocation = location,
            NextDirection = location.lineNum + 1 < rows.Count ? NextDirection.Left : NextDirection.Break
        };
    }

    public static GuardMovementResult GetGuardMovementLeftQuery(List<List<char>> rows, (int lineNum, int rowIndex) location)
    {
        while (location.rowIndex - 1 >= 0 && rows[location.lineNum][location.rowIndex - 1] != '#')
        {
            rows[location.lineNum][location.rowIndex] = 'X';
            location = (location.lineNum, location.rowIndex - 1);
        }

        return new GuardMovementResult
        {
            MarkedRows = rows,
            CurrentLocation = location,
            NextDirection = location.rowIndex - 1 >= 0 ? NextDirection.Up : NextDirection.Break
        };
    }

    public static int GetTotalSpotCountQuery(List<List<char>> rows)
    {
        int totalCount = 0;

        foreach (var row in rows)
        {
            foreach (char c in row)
            {
                if (c == 'X')
                    totalCount++;
            }
        }

        return totalCount;
    }

    public static int GetTotalGuardMovementSumQuery(List<List<char>> rows, (int lineNum, int rowIndex) location)
    {
        var guardMovementResult = new GuardMovementResult
        {
            MarkedRows = rows,
            CurrentLocation = location,
            NextDirection = NextDirection.Up
        };

        while (guardMovementResult.NextDirection != NextDirection.Break)
        {
            switch (guardMovementResult.NextDirection)
            {
                case NextDirection.Up:
                    guardMovementResult = GetGuardMovementUpQuery(guardMovementResult.MarkedRows!, guardMovementResult.CurrentLocation);
                    break;
                case NextDirection.Right:
                    guardMovementResult = GetGuardMovementRightQuery(guardMovementResult.MarkedRows!, guardMovementResult.CurrentLocation);
                    break;
                case NextDirection.Down:
                    guardMovementResult = GetGuardMovementDownQuery(guardMovementResult.MarkedRows!, guardMovementResult.CurrentLocation);
                    break;
                case NextDirection.Left:
                    guardMovementResult = GetGuardMovementLeftQuery(guardMovementResult.MarkedRows!, guardMovementResult.CurrentLocation);
                    break;
            }
        }

        return GetTotalSpotCountQuery(guardMovementResult.MarkedRows!) + 1;
    }
}