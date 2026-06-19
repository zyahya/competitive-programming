using System.Linq;

namespace LeetCode.Solutions.max_consecutive_ones;

public class MaxConsecutiveOnes_StringSplit
{
    public static int Solution(int[] nums)
    {
        string binaryString = string.Concat(nums);
        return binaryString.Split("0").Max(i => i.Length);
    }
}
