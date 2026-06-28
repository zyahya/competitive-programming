namespace Codewars.Solutions.Kyu7.vowel_count;

public class VowelCount_Loop
{
    public static int Solution(string str)
    {
        int vowelCount = 0;

        for (int i = 0; i < str.Length; i++)
        {
            switch (str[i])
            {
                case 'a':
                case 'e':
                case 'o':
                case 'u':
                case 'i':
                    vowelCount++;
                    break;
            }
        }

        return vowelCount;
    }
}
