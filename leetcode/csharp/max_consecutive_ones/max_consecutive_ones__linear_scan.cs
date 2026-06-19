namespace LeetCode.Solutions.max_consecutive_ones;

public class MaxConsecutiveOnes_LinearScan
{
    public static int Solution(int[] nums)
    {
        int max = 0;
        int count = 0;

        foreach (int n in nums)
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
