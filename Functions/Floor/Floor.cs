class Floor
{
    public int[] input;
    public long[] elements;
    public int arraySize;
    public int queryCount;

    public void takeInput()
    {
        this.arraySize = input[0];
        this.queryCount = input[1];
        this.input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        this.elements = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
    }
    public void floorOfTheSubArray(string[] args)
    {
        long[] sumOfElements = new long[this.arraySize + 1];
        sumOfElements[0] = 0;
        for (int i = 1; i <= this.arraySize; i++)
        {
            sumOfElements[i] = sumOfElements[i - 1] + this.elements[i - 1];
        }
        for (var x = 0; x < queryCount; x++)
        {
            var queryRange = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int leftIndex = queryRange[0];
            int rightIndex = queryRange[1];
            Console.WriteLine((long)((long)(sumOfElements[rightIndex] - sumOfElements[leftIndex - 1]) / (rightIndex - leftIndex + 1)));
        }
    }
}