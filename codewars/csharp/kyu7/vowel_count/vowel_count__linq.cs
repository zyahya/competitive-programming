using System.Linq;

namespace Codewars.Solutions.kyu7.vowel_count;

public class VowelCount_Linq
{
    public static int Solution(string str)
    {
        return str.Count("aeoui".Contains);
    }
}
