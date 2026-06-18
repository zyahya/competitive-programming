using System.Linq;

namespace LeetCode.Solutions.q389_find_the_difference;

public class FindTheDifference_Sorting
{
    public static char Solution(string s, string t)
    {
        if (s == string.Empty)
        {
            return t[0];
        }

        var sortedS = s.ToList();
        sortedS.Sort();

        var sortedT = t.ToList();
        sortedT.Sort();

        for (var i = 0; i < s.Length; i++)
        {
            if (sortedT[i] != sortedS[i])
            {
                return sortedT[i];
            }
        }

        return sortedT[^1];
    }
}
