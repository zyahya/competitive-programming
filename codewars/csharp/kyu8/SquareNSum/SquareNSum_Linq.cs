using System.Linq;

namespace Codewars.Solutions.Kyu8.SquareNSum;

public class SquareNSum_Linq
{
    public static int Solution(int[] numbers)
    {
        return numbers.Sum(x => x * x);
    }
}
