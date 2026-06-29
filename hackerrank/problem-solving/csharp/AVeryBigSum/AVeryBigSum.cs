using System.Collections.Generic;

namespace Hackerrank.Solutions.AVeryBigSum;

public class AVeryBigSum
{
    public static long Solution(List<long> ar)
    {
        long total = 0;

        foreach (long item in ar)
        {
            total += item;
        }

        return total;
    }
}
