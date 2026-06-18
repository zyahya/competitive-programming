using System.Collections.Generic;
using System.Linq;

namespace Codewars.Solutions.kyu6.find_the_unique_number;

public class FindTheUniqueNumber_Linq
{
    public static int Solution(IEnumerable<int> numbers)
    {
        if (numbers.Count() < 0)
        {
            return 0;
        }

        int common = default;
        int first = numbers.Skip(1).Take(1).First();
        int second = numbers.Skip(2).Take(1).First();
        int third = numbers.Skip(3).Take(1).First();

        if (first == second)
        {
            common = first;
        }
        else if (second == third)
        {
            common = second;
        }
        else
        {
            common = third;
        }

        return numbers.First(x => x != common);
    }
}
