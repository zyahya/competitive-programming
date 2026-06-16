using System.Collections.Generic;
using System.Linq;

namespace Codewars.Solutions.kyu6.split_string;

public class SplitString
{
    public static string[] Solution(string str)
    {
        var pointer = 0;
        string[] output = [];

        while (pointer < str.Length)
        {
            if (pointer + 1 == str.Length)
            {
                output = output.Append($"{str[pointer]}_").ToArray();
                break;
            }

            output = output.Append($"{str[pointer]}{str[pointer + 1]}").ToArray();
            pointer += 2;
        }

        return output;
    }
}
