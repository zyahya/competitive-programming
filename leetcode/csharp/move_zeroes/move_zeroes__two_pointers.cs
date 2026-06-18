namespace LeetCode.Solutions.q283_move_zeroes;

public class MoveZeroes_TwoPointers
{
    public static int[] Solution(int[] nums)
    {
        int left = 0;
        int right = 0;

        while (right < nums.Length)
        {
            int leftN = nums[left];
            int rightN = nums[right];

            if (leftN == 0 && rightN != 0)
            {
                (nums[right], nums[left]) = (nums[left], nums[right]);

                left++;
                right++;
                continue;
            }
            else if (leftN != 0 && rightN == 0)
            {
                left++;
                continue;
            }

            right++;
        }

        return nums;
    }
}
