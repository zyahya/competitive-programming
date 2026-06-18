namespace Codewars.Solutions.kyu5.moving_zeroes_to_the_end;

public class MovingZeroesToTheEndTests
{
    [Theory]
    [InlineData(new int[] { 4, 2, 4, 0, 0, 3, 0, 5, 1, 0 }, new int[] { 4, 2, 4, 3, 5, 1, 0, 0, 0, 0 })]
    [InlineData(new int[] { 1, 2, 0, 1, 0, 1, 0, 3, 0, 1 }, new int[] { 1, 2, 1, 1, 3, 1, 0, 0, 0, 0 })]
    public void Test_Default_Solution(int[] input, int[] output)
    {
        var result = MovingZeroesToTheEnd__TwoPointers.Solution(input);

        Assert.Equal(output, result);
    }
}
