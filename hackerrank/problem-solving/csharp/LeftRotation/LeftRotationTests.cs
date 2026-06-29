using System.Collections.Generic;

namespace Hackerrank.Solutions.LeftRotation;

public class LeftRotationTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test1(int d, List<int> arr, List<int> expectedResult)
    {
        List<int> result = LeftRotation.Solution(d, arr);

        Assert.Equal(expectedResult, result);
    }

    public static IEnumerable<object[]> TestData =>
    [
        [2, new List<int> { 1, 2, 3, 4, 5 }, new List<int> { 3, 4, 5, 1, 2 }]
    ];
}
