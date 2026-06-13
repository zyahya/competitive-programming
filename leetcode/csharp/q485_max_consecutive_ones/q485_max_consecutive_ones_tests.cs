namespace LeetCode.Solutions.q485_max_consecutive_ones;

public class Q485_MaxConsecutiveOnesTests
{
    [Theory]
    [InlineData(new int[] { 1, 1, 0, 1, 1, 1 }, 3)]
    [InlineData(new int[] { 1, 0, 1, 1, 0, 1 }, 2)]
    public void Test1(int[] input, int expectedCount)
    {
        var result = Q485_MaxConsecutiveOnes.Solution(input);

        Assert.Equal(expectedCount, result);
    }

    [Theory]
    [InlineData(new int[] { 1, 1, 0, 1, 1, 1 }, 3)]
    [InlineData(new int[] { 1, 0, 1, 1, 0, 1 }, 2)]
    public void Test2(int[] input, int expectedCount)
    {
        var result = Q485_MaxConsecutiveOnes_Optimized.Solution(input);

        Assert.Equal(expectedCount, result);
    }
}
