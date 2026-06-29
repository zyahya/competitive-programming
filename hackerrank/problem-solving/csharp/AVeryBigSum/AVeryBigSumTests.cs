using System.Collections.Generic;

namespace Hackerrank.Solutions.AVeryBigSum;

public class AVeryBigSumTests
{
    [Fact]
    public void Test1()
    {
        List<long> input = [1000000001, 1000000002, 1000000003, 1000000004, 1000000005];
        long result = AVeryBigSum.Solution(input);
        Assert.Equal(5000000015, result);
    }
}
