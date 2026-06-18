namespace LeetCode.Solutions.q125_valid_palindrome;

public class Q125_ValidPalindromeTests
{
    [Theory]
    [InlineData("A man, a plan, a canal: Panama", true)]
    [InlineData("race a car", false)]
    [InlineData(" ", true)]
    [InlineData("0p", false)]
    [InlineData(".a", true)]
    [InlineData("a", true)]
    public void StringBuilder(string input, bool expectedResult)
    {
        var result = Q125_ValidPalindrome_StringBuilder.Solution(input);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("A man, a plan, a canal: Panama", true)]
    [InlineData("race a car", false)]
    [InlineData(" ", true)]
    [InlineData("0p", false)]
    [InlineData(".a", true)]
    [InlineData("a", true)]
    public void SkipNonAlphabetical(string input, bool expectedResult)
    {
        var result = Q125_ValidPalindrome_SkipNonAlphabetical.Solution(input);

        Assert.Equal(expectedResult, result);
    }
}
