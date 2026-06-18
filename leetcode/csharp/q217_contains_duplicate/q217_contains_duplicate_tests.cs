namespace LeetCode.Solutions.q217_contains_duplicate;

public class Q217_ContainsDuplicateTests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 1 }, true)]
    [InlineData(new int[] { 1, 2, 3, 4 }, false)]
    [InlineData(new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 }, true)]
    public void Q217_ContainsDuplicate_Solution_1(int[] input, bool expectedResult)
    {
        var result = ContainsDuplicate_HashSet.Solution(input);

        Assert.Equal(expectedResult, result);
    }
}
