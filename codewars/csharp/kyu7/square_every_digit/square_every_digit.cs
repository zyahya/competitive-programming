using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Solutions.kyu7.square_every_digit;

public class SquareEveryDigit
{
    public static int Solution(int n)
    {
        return n.ConvertIntToIntList()
            .PowerEachItem()
            .ConcatIntList();
    }
}

public static class Helpers
{
    public static List<int> ConvertIntToIntList(this int value)
    {
        return Convert.ToString(value)
            .ToList()
            .ConvertAll(c => (int)char.GetNumericValue(c));
    }

    public static List<int> PowerEachItem(this List<int> value)
    {
        return value.Select(i => i * i).ToList();
    }

    public static int ConcatIntList(this List<int> value)
    {
        return Convert.ToInt32(
            value.ConvertIntListToString()
        );
    }

    public static string ConvertIntListToString(this List<int> value)
    {
        return string.Concat(value);
    }
}
