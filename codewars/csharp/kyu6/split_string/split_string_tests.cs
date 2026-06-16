namespace Codewars.Solutions.kyu6.split_string;

public class SplitStringTests
{
    [Theory]
    [InlineData("abc", new string[] { "ab", "c_" })]
    [InlineData("abcdef", new string[] { "ab", "cd", "ef" })]
    public void Solution_1(string input, string[] output)
    {
        var result = SplitString.Solution(input);

        Assert.Equal(output, result);
    }

    [Theory]
    [InlineData("abc", new string[] { "ab", "c_" })]
    [InlineData("abcdef", new string[] { "ab", "cd", "ef" })]
    public void Solution_2(string input, string[] output)
    {
        var result = SplitString_Optimized.Solution(input);

        Assert.Equal(output, result);
    }
}
