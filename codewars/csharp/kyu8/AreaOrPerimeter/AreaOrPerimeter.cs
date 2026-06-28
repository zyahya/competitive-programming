namespace Codewars.Solutions.Kyu8.AreaOrPerimeter;

public class AreaOrPerimeter
{
    public static int Solution(int l, int w)
    {
        return l == w ? l * l : (l + w) * 2;
    }
}
