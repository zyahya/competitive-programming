namespace Codewars.Solutions.Kyu5.MovingZeroesToTheEnd;

public class MovingZeroesToTheEnd__TwoPointers
{
    public static int[] Solution(int[] arr)
    {
        int left = 0;
        int right = 0;

        while (right < arr.Length)
        {
            if (arr[right] != 0)
            {
                (arr[left], arr[right]) = (arr[right], arr[left]);
                left++;
            }
            right++;
        }

        return arr;
    }
}
