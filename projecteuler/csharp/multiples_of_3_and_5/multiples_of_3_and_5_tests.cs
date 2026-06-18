namespace ProjectEuler.multiples_of_3_and_5;

public class MultiplesOf3And5_Tests
{
    [Theory]
    [InlineData(2, 0)]
    [InlineData(10, 23)]
    [InlineData(100, 2318)]
    public void Test1(int input, int expectedResult)
    {
        var result = MultiplesOf3And5_BruteForce.Solution(input);

        Assert.Equal(expectedResult, result);
    }
}
