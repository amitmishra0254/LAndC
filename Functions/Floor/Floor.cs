class Floor
{
    public int[] input;
    public long[] elements;
    public List<long> answers;
    public int arraySize;
    public int queryCount;

    public void takeInput()
    {
        Console.WriteLine("Input:");
        input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        this.arraySize = input[0];
        this.queryCount = input[1];
        this.elements = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
        this.answers = new List<long>();
    }
    public void floorOfTheSubArray()
    {
        long[] sumOfElements = new long[this.arraySize + 1];
        sumOfElements[0] = 0;
        for (int i = 1; i <= this.arraySize; i++)
        {
            sumOfElements[i] = sumOfElements[i - 1] + this.elements[i - 1];
        }
        for (var index = 0; index < queryCount; index++)
        {
            var queryRange = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int leftIndex = queryRange[0];
            int rightIndex = queryRange[1];
            answers.Add((long)((long)(sumOfElements[rightIndex] - sumOfElements[leftIndex - 1]) / (rightIndex - leftIndex + 1)));
        }
        Console.WriteLine("Output:");
        foreach (var element in answers)
        {
            Console.WriteLine(element);
        }
    }
}
