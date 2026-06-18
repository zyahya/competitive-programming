using System.Text;

namespace LeetCode.Solutions.valid_palindrome;

public class Q125_ValidPalindrome_StringBuilder
{
    public static bool Solution(string s)
    {
        StringBuilder sb = new();

        for (int i = 0; i < s.Length; i++)
        {
            char current = char.ToLower(s[i]);

            if (char.IsLetterOrDigit(current))
            {
                sb.Append(current);
            }
        }

        string filtered = sb.ToString();
        int left = 0;
        int right = sb.Length - 1;

        while (left <= right)
        {
            char leftChar = filtered[left];
            char rightChar = filtered[right];

            if (leftChar != rightChar)
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }
}
