using System.Collections.Generic;

namespace HackerRank.Solutions.camel_case;

public class CamelCase
{
    public static int Solution(string input)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
        {
            return 0;
        }

        List<char> result = [];

        foreach (char currentChar in input)
        {
            if (char.IsUpper(currentChar))
            {
                result.Add(' ');
                result.Add(currentChar);
            }
            else
            {
                result.Add(currentChar);
            }
        }

        return string.Concat(result).Split(' ').Length;
    }
}
