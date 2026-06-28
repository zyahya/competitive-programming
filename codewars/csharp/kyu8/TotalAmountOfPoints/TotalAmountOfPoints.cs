namespace Codewars.Solutions.Kyu8.TotalAmountOfPoints;

public class TotalAmountOfPoints
{
    public static int Solution(string[] games)
    {
        short totalPoints = 0;

        foreach (string match in games)
        {
            if (match[0] > match[2])
            {
                totalPoints += 3;
            }
            else if (match[0] == match[2])
            {
                totalPoints += 1;
            }
        }

        return totalPoints;
    }
}
