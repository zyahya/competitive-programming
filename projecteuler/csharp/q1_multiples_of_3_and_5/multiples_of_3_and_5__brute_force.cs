namespace ProjectEuler.q1_multiples_of_3_and_5;

public class MultiplesOf3And5_BruteForce
{
    public static int Solution(int n)
    {
        List<int> qualifiedNumbers = [];

        for (int i = 1; i < n; i++)
        {
            if (i % 3 == 0 || i % 5 == 0)
            {
                qualifiedNumbers.Add(i);
            }
        }

        return qualifiedNumbers.Sum();
    }
}
