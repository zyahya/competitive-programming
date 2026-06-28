using System;

namespace Codewars.Solutions.Kyu8.counting_sheep;

public class CountingSheep
{
    public static int Solution(bool[] sheeps)
    {
        return sheeps.Count(true);
    }
}
