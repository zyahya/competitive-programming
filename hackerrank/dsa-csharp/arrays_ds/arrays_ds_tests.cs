using System.Collections.Generic;

namespace HackerRank.Solutions.arrays_ds;

public class ArraysDSTests
{
    [Fact]
    public void Test1()
    {
        List<int> result = ArraysDS.Solution([1, 4, 3, 2]);
        Assert.Equal([2, 3, 4, 1], result);
    }
}
