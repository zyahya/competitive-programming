namespace Codewars.Solutions.kyu6.split_string;

public class SplitString_Optimized
{
    public static string[] Solution(string str)
    {
        if (str.Length % 2 != 0)
        {
            str += "_";
        }

        string[] output = new string[str.Length / 2];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = $"{str[i * 2]}{str[i * 2 + 1]}";
        }

        return output;
    }
}
