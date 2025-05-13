public class DivisorCounter
{
    public static int CountMatchingDivisors(int number)
    {
        if (number < 0) throw new ArgumentException("Input must be non-negative");

        int count = 0;
        for (int index = 1; index < number; index++)
        {
            if (CountDivisors(index) == CountDivisors(index+1))
            {
                count++;
            }
        }
        return count;
    }

    private static int CountDivisors(int number)
    {
        int count = 0;
        for (int index = 1; index <= Math.Sqrt(number); index++)
        {
            if (number%index == 0)
            {
                if(index == number / index)
                {
                    count++;
                }
                else
                {
                    count += 2;
                }
            }
        }
        return count;
    }
}