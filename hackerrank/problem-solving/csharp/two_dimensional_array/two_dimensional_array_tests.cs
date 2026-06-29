using System.Collections.Generic;
using System.Linq;

namespace HackerRank.Solutions.two_dimensional_array;

public class TwoDimensionalArrayTests
{
    [Theory]
    [InlineData(
        new[] { 1, 1, 1, 0, 0, 0 },
        new[] { 0, 1, 0, 0, 0, 0 },
        new[] { 1, 1, 1, 0, 0, 0 },
        new[] { 0, 0, 2, 4, 4, 0 },
        new[] { 0, 0, 0, 2, 0, 0 },
        new[] { 0, 0, 1, 2, 4, 0 },
        19)]
    [InlineData(
        new[] { 1, 1, 1, 0, 0, 0 },
        new[] { 0, 1, 0, 0, 0, 0 },
        new[] { 1, 1, 1, 0, 0, 0 },
        new[] { 0, 9, 2, -4, -4, 0 },
        new[] { 0, 0, 0, -2, 0, 0 },
        new[] { 0, 0, -1, -2, -4, 0 },
        13)]
    [InlineData(
        new[] { -9, -9, -9, 1, 1, 1 },
        new[] { 0, -9, 0, 4, 3, 2 },
        new[] { -9, -9, -9, 1, 2, 3 },
        new[] { 0, 0, 8, 6, 6, 0 },
        new[] { 0, 0, 0, -2, 0, 0 },
        new[] { 0, 0, 1, 2, 4, 0 },
        28)]
    [InlineData(
        new[] { -1, -1, 0, -9, -2, -2 },
        new[] { -2, -1, -6, -8, -2, -5 },
        new[] { -1, -1, -1, -2, -3, -4 },
        new[] { -1, -9, -2, -4, -4, -5 },
        new[] { -7, -3, -3, -2, -9, -9 },
        new[] { -1, -3, -1, -2, -4, -5 },
        -6)]
    public void Test1(int[] r0, int[] r1, int[] r2, int[] r3, int[] r4, int[] r5, int expectedResult)
    {
        List<List<int>> input = new List<List<int>>
        {
            r0.ToList(), r1.ToList(), r2.ToList(), r3.ToList(), r4.ToList(), r5.ToList()
        };

        int result = TwoDimensionalArray.Solution(input);

        Assert.Equal(expectedResult, result);
    }
}

/* Test 1 input
1 1 1 0 0 0
0 1 0 0 0 0
1 1 1 0 0 0
0 0 2 4 4 0
0 0 0 2 0 0
0 0 1 2 4 0
 */

/* Test 1 output
19
 */

/* Test 2 input
1 1 1 0 0 0
0 1 0 0 0 0
1 1 1 0 0 0
0 9 2 -4 -4 0
0 0 0 -2 0 0
0 0 -1 -2 -4 0
 */

/* Test 2 output
13
 */

/* Test 3 input
-9 -9 -9 1 1 1
0 -9 0 4 3 2
-9 -9 -9 1 2 3
0 0 8 6 6 0
0 0 0 -2 0 0
0 0 1 2 4 0
 */

/* Test 3 output
28
 */
