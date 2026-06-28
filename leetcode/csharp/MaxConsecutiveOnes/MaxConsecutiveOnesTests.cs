namespace LeetCode.Solutions.MaxConsecutiveOnes;

public class MaxConsecutiveOnesTests
{
    [Theory]
    [InlineData(new int[] { 1, 1, 0, 1, 1, 1 }, 3)]
    [InlineData(new int[] { 1, 0, 1, 1, 0, 1 }, 2)]
    public void Test1(int[] input, int expectedCount)
    {
        int result = MaxConsecutiveOnes_StringSplit.Solution(input);

        Assert.Equal(expectedCount, result);
    }

    [Theory]
    [InlineData(new int[] { 1, 1, 0, 1, 1, 1 }, 3)]
    [InlineData(new int[] { 1, 0, 1, 1, 0, 1 }, 2)]
    public void Test2(int[] input, int expectedCount)
    {
        int result = MaxConsecutiveOnes_LinearScan.Solution(input);

        Assert.Equal(expectedCount, result);
    }
}
