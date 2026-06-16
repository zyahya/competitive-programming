using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace Codewars.Solutions.kyu6.split_string;

public class SplitStringTests
{
    [Theory]
    [InlineData("abc", new string[] { "ab", "c_" })]
    [InlineData("abcdef", new string[] { "ab", "cd", "ef" })]
    public void Test1(string input, string[] output)
    {
        var result = SplitString.Solution(input);

        Assert.Equal(output, result);
    }
}
