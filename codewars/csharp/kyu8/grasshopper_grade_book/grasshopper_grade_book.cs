namespace Codewars.Solutions.kyu8.grasshopper_grade_book;

public class GrasshopperGradeBook
{
    public static char Solution(int s1, int s2, int s3)
    {
        return ((s1 + s2 + s3) / 30) switch
        {
            10 => 'A',
            9 => 'A',
            8 => 'B',
            7 => 'C',
            6 => 'D',
            _ => 'F'
        };
    }
}
