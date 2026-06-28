namespace LeetCode.Solutions.TwoSum;

public class TwoSum_Tests
{
    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
    [InlineData(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
    public void TwoSum_Solution_1(int[] nums, int target, int[] expectedResult)
    {
        int[] result = TwoSum_BruteForce.Solution(nums, target);

        Assert.Equal(expectedResult, result);
    }
}
