namespace Codewars.Solutions.kyu8.total_amount_of_points;

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
