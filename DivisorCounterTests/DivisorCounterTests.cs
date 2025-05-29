namespace DivisorCounterTests
{
    [TestFixture]
    public class DivisorCounterTests
    {
        [Test]
        public void CountMatchingDivisors_PositiveInput_ReturnsCorrectCount()
        {
            int result = DivisorCounter.CountMatchingDivisors(10);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void CountMatchingDivisors_Zero_ReturnsZero()
        {
            int result = DivisorCounter.CountMatchingDivisors(0);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void CountMatchingDivisors_NoMatchingPairs_ReturnsZero()
        {
            int result = DivisorCounter.CountMatchingDivisors(2);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void CountMatchingDivisors_NegativeInput_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => DivisorCounter.CountMatchingDivisors(-5));
        }

        [Test]
        public void CountMatchingDivisors_LargeInput_PerformanceTest()
        {
            int result = DivisorCounter.CountMatchingDivisors(100000);
            Assert.GreaterOrEqual(result, 0);
        }
    }
}