namespace LeetCode.Solutions.ValidPalindrome;

public class Q125_ValidPalindrome_SkipNonAlphabetical
{
    public static bool Solution(string s)
    {
        int left = 0, right = s.Length - 1;

        char leftChar;
        char rightChar;

        while (left <= right)
        {
            leftChar = char.ToLower(s[left]);
            rightChar = char.ToLower(s[right]);

            if (!char.IsLetterOrDigit(leftChar))
            {
                left++;
                continue;
            }

            if (!char.IsLetterOrDigit(rightChar))
            {
                right--;
                continue;
            }

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
