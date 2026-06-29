using System;
using System.Collections.Generic;

namespace Hackerrank.Solutions.TwoDimensionalArray;

public class TwoDimensionalArray
{
    public static int Solution(List<List<int>> arr)
    {
        if (arr.Count <= 0)
        {
            return 0;
        }

        List<List<int>> calculatedSet = [];

        for (int i = 0; i < arr.Count - 2; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                List<int> row = arr[k + i];
                List<int> set = [];

                for (int j = 0; j < row.Count - 2; j++) // row
                {
                    if (k == 1)
                    {
                        set.Add(row[j + 1]);
                    }
                    else
                    {
                        set.Add(row[j] + row[j + 1] + row[j + 2]);
                    }
                }

                calculatedSet.Add(set);
            }
        }

        List<List<int>> combinedSets = [];

        for (int i = 0; i < calculatedSet.Count; i += 3)
        {
            List<int> top = calculatedSet[i];
            List<int> mid = calculatedSet[i + 1];
            List<int> bot = calculatedSet[i + 2];

            List<int> hourglass = [];

            for (int j = 0; j < top.Count; j++)
            {
                int totalHourglass = top[j] + mid[j] + bot[j];
                hourglass.Add(totalHourglass);
            }

            combinedSets.Add(hourglass);
        }

        int max = int.MinValue;

        foreach (List<int> row in combinedSets)
        {
            Console.WriteLine(string.Join(", ", row));
            foreach (int col in row)
            {
                Console.WriteLine(col);
                max = Math.Max(col, max);
            }
        }

        return max;
    }
}
