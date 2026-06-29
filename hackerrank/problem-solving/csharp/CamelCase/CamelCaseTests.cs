namespace Hackerrank.Solutions.CamelCase;

public class CamelCaseTests
{
    [Theory]
    [InlineData("saveChangesInTheEditor", 5)]
    [InlineData("", 0)]
    [InlineData(" ", 0)]
    public void Test1(string input, int expectedResult)
    {
        int result = CamelCase.Solution(input);
        Assert.Equal(expectedResult, result);
    }
}
