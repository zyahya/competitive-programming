namespace LeetCode.Solutions.binary_search;

public class Q704_BinarySearch
{
    public static int Solution(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int middle = (left + right) / 2;

            if (nums[middle] == target)
            {
                return middle;
            }

            if (nums[middle] < target)
            {
                left = ++middle;
            }
            else if (nums[middle] > target)
            {
                right = --middle;
            }
        }

        return -1;
    }
}
