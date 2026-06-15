using System.Collections.Generic;

namespace LeetCode.Solutions.q217_contains_duplicate;

public class Q217_ContainsDuplicate
{
    public static bool Solution(int[] nums)
    {
        var set = new HashSet<int>(nums);
        return set.Count < nums.Length;
    }
}
