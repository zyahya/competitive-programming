using System.Text;

namespace Codewars.Solutions.Kyu6.ConvertingStringToCamelCase;

public class ConvertingStringToCamelCase_StringBuilder
{
    public static string Solution(string str)
    {
        StringBuilder sb = new(str);

        for (int i = 0; i < sb.Length - 1; i++)
        {
            if (sb[i] == '-' || sb[i] == '_')
            {
                sb.Replace($"{sb[i]}{sb[i + 1]}", $"{char.ToUpper(sb[i + 1])}");
            }
        }

        return sb.ToString();
    }
}
