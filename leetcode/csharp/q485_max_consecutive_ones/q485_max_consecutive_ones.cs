using System.Linq;

namespace LeetCode.Solutions.q485_max_consecutive_ones;

public class Q485_MaxConsecutiveOnes
{
    public static int Solution(int[] nums)
    {
        var binaryString = string.Concat(nums);
        return binaryString.Split("0").Max(i => i.Length);
    }
}
