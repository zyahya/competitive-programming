namespace LeetCode.Solutions.q283_move_zeroes;

public class Q283_MoveZeroesTests
{
    [Theory]
    [InlineData(new int[] { 4, 2, 4, 0, 0, 3, 0, 5, 1, 0 }, new int[] { 4, 2, 4, 3, 5, 1, 0, 0, 0, 0 })]
    [InlineData(new int[] { 1, 2, 0, 1, 0, 1, 0, 3, 0, 1 }, new int[] { 1, 2, 1, 1, 3, 1, 0, 0, 0, 0 })]
    public void Test_Default_Solution(int[] input, int[] output)
    {
        var result = Q283_MoveZeroes.Solution(input);

        Assert.Equal(output, result);
    }
}
