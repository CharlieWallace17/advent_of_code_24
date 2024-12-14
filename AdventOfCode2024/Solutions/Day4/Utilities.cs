namespace AdventOfCode2024.Solutions.Day4;

public static class Utilities
{
    public static List<string> GetRowsFromFileStringQuery(string filePath)
    {
        string fileString = File.ReadAllText(filePath);

        return fileString.Split('\n').ToList();
    }

    public static int GetHorizontalCountQuery(List<string> rows)
    {
        int horizontalCount = 0;

        for (int i = 0; i < rows.Count; i++)
        {
            for (int j = 0; j < rows[i].Length; j++)
            {
                if (j + 3 < rows[i].Length)
                    if (rows[i][j] == 'X' &&
                        rows[i][j + 1] == 'M' &&
                        rows[i][j + 2] == 'A' &&
                        rows[i][j + 3] == 'S')
                    {
                        horizontalCount++;
                    }
                    else if (rows[i][j] == 'S' &&
                             rows[i][j + 1] == 'A' &&
                             rows[i][j + 2] == 'M' &&
                             rows[i][j + 3] == 'X')
                    {
                        horizontalCount++;
                    }
            }
        }

        return horizontalCount;
    }

    public static int GetVerticalCountQuery(List<string> rows)
    {
        int verticalCount = 0;

        for (int i = 0; i < rows.Count; i++)
        {
            if (i + 3 >= rows.Count) continue;
            for (int j = 0; j < rows[i].Length; j++)
            {
                switch (rows[i][j])
                {
                    case 'X' when
                        rows[i + 1][j] == 'M' &&
                        rows[i + 2][j] == 'A' &&
                        rows[i + 3][j] == 'S':
                    case 'S' when
                        rows[i + 1][j] == 'A' &&
                        rows[i + 2][j] == 'M' &&
                        rows[i + 3][j] == 'X':
                        verticalCount++;
                        break;
                }
            }
        }

        return verticalCount;
    }

    public static int GetDiagonalCountQuery(List<string> rows)
    {
        int diagonalCount = 0;

        for (int i = 0; i < rows.Count; i++)
        {
            if (i + 3 >= rows.Count) continue;
            for (int j = 0; j < rows[i].Length; j++)
            {
                if (rows[i][j] == 'X' &&
                    rows[i + 1][j + 1] == 'M' &&
                    rows[i + 2][j + 2] == 'A' &&
                    rows[i + 3][j + 3] == 'S')
                {
                    diagonalCount++;
                }
                else if (rows[i][j] == 'S' &&
                         rows[i + 1][j + 1] == 'A' &&
                         rows[i + 2][j + 2] == 'M' &&
                         rows[i + 3][j + 3] == 'X')
                {
                    diagonalCount++;
                }

                if (j + 3 < rows[i].Length)
                    if (rows[i][j + 3] == 'X' &&
                        rows[i + 1][j + 2] == 'M' &&
                        rows[i + 2][j + 1] == 'A' &&
                        rows[i + 3][j] == 'S')
                    {
                        diagonalCount++;
                    }
                    else if (rows[i][j + 3] == 'S' &&
                             rows[i + 1][j + 2] == 'A' &&
                             rows[i + 2][j + 1] == 'M' &&
                             rows[i + 3][j] == 'X')
                    {
                        diagonalCount++;
                    }
            }
        }

        return diagonalCount;
    }

    public static int GetXmasCountQuery(List<string> rows)
    {
        int diagonalCount = 0;

        for (int i = 0; i < rows.Count; i++)
        {
            if (i + 2 >= rows.Count) continue;
            for (int j = 0; j < rows[i].Length; j++)
            {
                if (j + 2 >= rows[i].Length) continue;
                //MAS-MAS
                if (rows[i][j] == 'M' &&
                    rows[i + 1][j + 1] == 'A' &&
                    rows[i + 2][j + 2] == 'S'
                    &&
                    rows[i][j + 2] == 'M' &&
                    rows[i + 1][j + 1] == 'A' &&
                    rows[i + 2][j] == 'S')
                {
                    diagonalCount++;
                }
                //SAM-MAS
                else if (rows[i][j] == 'S' &&
                         rows[i + 1][j + 1] == 'A' &&
                         rows[i + 2][j + 2] == 'M'
                         &&
                         rows[i][j + 2] == 'M' &&
                         rows[i + 1][j + 1] == 'A' &&
                         rows[i + 2][j] == 'S')
                {
                    diagonalCount++;
                }
                //MAS-SAM
                else if (rows[i][j] == 'M' &&
                         rows[i + 1][j + 1] == 'A' &&
                         rows[i + 2][j + 2] == 'S'
                         &&
                         rows[i][j + 2] == 'S' &&
                         rows[i + 1][j + 1] == 'A' &&
                         rows[i + 2][j] == 'M')
                {
                    diagonalCount++;
                }
                //SAM-SAM
                else if (rows[i][j] == 'S' &&
                         rows[i + 1][j + 1] == 'A' &&
                         rows[i + 2][j + 2] == 'M'
                         &&
                         rows[i][j + 2] == 'S' &&
                         rows[i + 1][j + 1] == 'A' &&
                         rows[i + 2][j] == 'M')
                {
                    diagonalCount++;
                }
            }
        }

        return diagonalCount;
    }
}