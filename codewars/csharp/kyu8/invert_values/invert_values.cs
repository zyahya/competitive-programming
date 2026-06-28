using System.Linq;

namespace Codewars.Solutions.Kyu8.invert_values;

public class InvertValues
{
    public static int[] Solution(int[] input)
    {
        return input.Select(i => -i).ToArray();
    }
}
