public class DivisorCounter
{
    public static int CountMatchingDivisors(int number)
    {
        if (number < 0) throw new ArgumentException("Input must be non-negative");

        int count = 0;
        for (int index = 1; index < number; index++)
        {
            if (CountDivisors(index) == CountDivisors(index + 1))
            {
                count++;
            }
        }
        return count;
    }

    private static int CountDivisors(int num)
    {
        int count = 0;
        for (int index = 1; index <= Math.Sqrt(num); index++)
        {
            if (num % index == 0)
            {
                count += (index == num / index) ? 1 : 2;
            }
        }
        return count;
    }
}