using System.Collections.Generic;

namespace Hackerrank.Solutions.LeftRotation;

public class LeftRotation
{
    public static List<int> Solution(int d, List<int> arr)
    {
        for (int i = 0; i < d; i++)
        {
            int firstItem = arr[0];
            arr.Add(firstItem);
            arr.Remove(firstItem);
        }
        return arr;
    }
}
