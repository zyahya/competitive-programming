using System.Collections.Generic;

namespace Codewars.Solutions.kyu8.LarioAndMuigiPipeProblem;

public class LarioAndMuigiPipeProblemTests
{
    [Fact]
    public void Test1()
    {
        List<int> result = LarioAndMuigiPipeProblem.Solution([3, 6]);

        Assert.Equal([3, 4, 5, 6], result);
    }
}
