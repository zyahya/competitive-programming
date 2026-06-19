using System;
using System.Linq;

namespace Codewars.Solutions.kyu8.total_amount_of_points;

public class TotalAmountOfPoints
{
    public static int Solution(string[] games)
    {
        short totalPoints = 0;

        foreach (string match in games)
        {
            byte[] matchResult = match.Split(':').Select(x => Convert.ToByte(x)).ToArray();

            if (matchResult[0] > matchResult[1])
            {
                totalPoints += 3;
            }
            else if (matchResult[0] == matchResult[1])
            {
                totalPoints += 1;
            }
        }

        return totalPoints;
    }
}
