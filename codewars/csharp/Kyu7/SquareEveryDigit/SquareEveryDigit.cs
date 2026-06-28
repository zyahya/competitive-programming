using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Solutions.Kyu7.SquareEveryDigit;

public class SquareEveryDigit
{
    public static int Solution(int n)
    {
        return ConvertIntToIntList(n)
            .Sum(x => x * x);
    }

    public static List<int> ConvertIntToIntList(int value)
    {
        return Convert.ToString(value)
            .ToList()
            .ConvertAll(c => (int)char.GetNumericValue(c));
    }
}
