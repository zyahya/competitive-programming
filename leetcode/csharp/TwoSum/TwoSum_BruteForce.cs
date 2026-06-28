namespace LeetCode.Solutions.TwoSum;

public class TwoSum_BruteForce
{
    public static int[] Solution(int[] nums, int target)
    {
        int left = 0, right = left + 1;

        while (left < nums.Length)
        {
            if (nums[left] + nums[right] == target)
            {
                return [left, right];
            }

            if (right == nums.Length - 1)
            {
                left++;
                right = left + 1;
                continue;
            }

            right++;
        }

        return [];
    }
}
