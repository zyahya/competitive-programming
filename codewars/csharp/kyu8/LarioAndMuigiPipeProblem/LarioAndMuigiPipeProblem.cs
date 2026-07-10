using System.Collections.Generic;
using System.Linq;

namespace Codewars.Solutions.kyu8.LarioAndMuigiPipeProblem;

public class LarioAndMuigiPipeProblem
{
    public static List<int> Solution(List<int> numbers)
    {
        List<int> result = new(numbers.Last());

        for (int i = numbers.First(); i <= numbers.Last(); i++)
        {
            result.Add(i);
        }

        return result;
    }
}
