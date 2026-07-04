using System.Linq;

namespace Codewars.Solutions.Kyu7.VowelCount;

public class VowelCount_Linq
{
    public static int Solution(string str)
    {
        return str.Count("aeoui".Contains);
    }
}
