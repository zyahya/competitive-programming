namespace Codewars.Solutions.kyu6.find_the_unique_number;

public class FindTheUniqueNumberTests
{
    [Theory]
    [InlineData(new int[] { 1, 1, 1, 2, 1, 1 }, 2)]
    [InlineData(new int[] { 1, 2, 2, 2 }, 1)]
    [InlineData(new int[] { -2, 2, 2, 2 }, -2)]
    [InlineData(new int[] { 11, 11, 14, 11, 11 }, 14)]
    public void Linq(int[] input, int output)
    {
        var result = FindTheUniqueNumber_Linq.Solution(input);

        Assert.Equal(output, result);
    }
}
