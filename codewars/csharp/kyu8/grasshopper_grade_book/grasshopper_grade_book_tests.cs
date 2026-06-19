namespace Codewars.Solutions.kyu8.grasshopper_grade_book;

public class GrasshopperGradeBookTests
{
    [Theory]
    [InlineData(95, 90, 93, 'A')]
    [InlineData(70, 70, 100, 'B')]
    [InlineData(70, 71, 72, 'C')]
    [InlineData(65, 66, 60, 'D')]
    [InlineData(32, 15, 21, 'F')]
    public void Test1(int s1, int s2, int s3, char output)
    {
        var result = GrasshopperGradeBook.Solution(s1, s2, s3);

        Assert.Equal(output, result);
    }
}
