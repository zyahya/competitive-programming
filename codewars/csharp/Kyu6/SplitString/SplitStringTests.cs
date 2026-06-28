namespace Codewars.Solutions.Kyu6.SplitString;

public class SplitStringTests
{
    [Theory]
    [InlineData("abc", new string[] { "ab", "c_" })]
    [InlineData("abcdef", new string[] { "ab", "cd", "ef" })]
    public void Solution_1(string input, string[] output)
    {
        string[] result = SplitString.Solution(input);

        Assert.Equal(output, result);
    }

    [Theory]
    [InlineData("abc", new string[] { "ab", "c_" })]
    [InlineData("abcdef", new string[] { "ab", "cd", "ef" })]
    public void Solution_2(string input, string[] output)
    {
        string[] result = SplitString_Optimized.Solution(input);

        Assert.Equal(output, result);
    }
}
