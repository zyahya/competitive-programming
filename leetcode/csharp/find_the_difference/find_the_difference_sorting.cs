using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Solutions.find_the_difference;

public class FindTheDifference_Sorting
{
    public static char Solution(string s, string t)
    {
        if (s == string.Empty)
        {
            return t[0];
        }

        List<char> sortedS = s.ToList();
        sortedS.Sort();

        List<char> sortedT = t.ToList();
        sortedT.Sort();

        for (int i = 0; i < s.Length; i++)
        {
            if (sortedT[i] != sortedS[i])
            {
                return sortedT[i];
            }
        }

        return sortedT[^1];
    }
}
