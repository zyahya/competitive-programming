using System.Text;

namespace Codewars.Solutions.kyu6.converting_string_to_camel_case;

public class ConvertingStringToCamelCase_StringBuilder
{
    public static string Solution(string str)
    {
        var sb = new StringBuilder(str);

        for (int i = 0; i < sb.Length - 1; i++)
        {
            char currentChar = sb[i];
            char nextChat = sb[i + 1];

            if (currentChar == '-' || currentChar == '_')
            {
                sb.Remove(i, 2);
                sb.Insert(i, char.ToUpper(nextChat));
            }
        }

        return sb.ToString();
    }
}
