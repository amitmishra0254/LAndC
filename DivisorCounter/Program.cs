public class Program
{
    public static void Main(string[] args)
    {
        int numberOfCases = int.Parse(Console.ReadLine());

        var result = new List<int>();

        for (int index = 0; index < numberOfCases; index++)
        {
            int number = int.Parse(Console.ReadLine());
            try
            {
                result.Add(DivisorCounter.CountMatchingDivisors(number));
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: " + exception.Message);
            }
        }
        foreach (int divisor in result)
        {
            Console.WriteLine(divisor);
        }
    }
}
