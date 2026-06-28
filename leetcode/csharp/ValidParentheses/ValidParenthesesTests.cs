namespace LeetCode.Solutions.ValidParentheses;

public class ValidParentheses_Tests
{
    [Theory]
    [InlineData("[()]", true)]
    [InlineData("[()]}", false)]
    public void Test(string input, bool output)
    {
        bool result = ValidParentheses_Stack.Solution(input);

        Assert.Equal(output, result);
    }
}
