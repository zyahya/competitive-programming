namespace Neetcode.Solutions.binary_search;

public class BinarySearchTests
{
    [Theory]
    [InlineData(new int[] { -1, 0, 2, 4, 6, 8 }, 4, 3)]
    [InlineData(new int[] { -1, 0, 2, 4, 6, 8 }, 3, -1)]
    public void Test1(int[] nums, int target, int expected)
    {
        var result = BinarySearch.Solution(nums, target);
        Assert.Equal(expected, result);
    }
}
