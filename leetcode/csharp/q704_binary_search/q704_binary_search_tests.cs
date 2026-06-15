namespace LeetCode.Solutions.q704_binary_search;

public class Q704_BinarySearchTests
{
    [Theory]
    [InlineData(new int[] { -1, 0, 3, 5, 9, 12 }, 9, 4)]
    [InlineData(new int[] { -1, 0, 3, 5, 9, 12 }, 2, -1)]
    public void Q704_BinarySearch_Solution_1(int[] nums, int target, int expectedResult)
    {
        var result = Q704_BinarySearch.Solution(nums, target);

        Assert.Equal(expectedResult, result);
    }
}
