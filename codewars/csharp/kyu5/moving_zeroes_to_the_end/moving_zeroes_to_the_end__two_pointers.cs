namespace Codewars.Solutions.kyu5.moving_zeroes_to_the_end;

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
