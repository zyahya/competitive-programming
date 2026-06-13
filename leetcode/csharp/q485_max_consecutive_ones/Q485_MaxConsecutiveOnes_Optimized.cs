namespace LeetCode.Solutions.q485_max_consecutive_ones;

public class Q485_MaxConsecutiveOnes_Optimized
{
    public static int Solution(int[] nums)
    {
        int max = 0;
        int count = 0;

        foreach (var n in nums)
        {
            if (n == 1)
            {
                count++;

                max = max > count ? max : count;
            }
            else
            {
                count = 0;
            }
        }

        return max;
    }
}
