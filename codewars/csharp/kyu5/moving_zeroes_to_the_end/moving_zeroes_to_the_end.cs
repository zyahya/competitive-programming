namespace Codewars.Solutions.kyu5.moving_zeroes_to_the_end;

public class MovingZeroesToTheEnd
{
    public static int[] Solution(int[] arr)
    {
        int left = 0;
        int right = 0;

        while (right < arr.Length)
        {
            int leftN = arr[left];
            int rightN = arr[right];

            if (leftN == 0 && rightN != 0)
            {
                (arr[right], arr[left]) = (arr[left], arr[right]);

                left++;
                right++;
                continue;
            }
            else if (leftN != 0 && rightN == 0)
            {
                left++;
                continue;
            }

            right++;
        }

        return arr;
    }
}
