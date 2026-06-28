using System.Collections.Generic;

namespace LeetCode.Solutions.ContainsDuplicate;

public class ContainsDuplicate_HashSet
{
    public static bool Solution(int[] nums)
    {
        HashSet<int> set = new HashSet<int>(nums);
        return set.Count < nums.Length;
    }
}
