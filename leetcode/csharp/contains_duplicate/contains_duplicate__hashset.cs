using System.Collections.Generic;

namespace LeetCode.Solutions.q217_contains_duplicate;

public class ContainsDuplicate_HashSet
{
    public static bool Solution(int[] nums)
    {
        var set = new HashSet<int>(nums);
        return set.Count < nums.Length;
    }
}
