using System.Linq;

namespace Codewars.Solutions.Kyu8.square_n_sum;

public class SquareNSum_Linq
{
    public static int Solution(int[] numbers)
    {
        return numbers.Sum(x => x * x);
    }
}
