using ATMMachine.Constants;

namespace ATMMachine.Exceptions
{
    public class DailyLimitExceededException : Exception
    {
        public DailyLimitExceededException(string message)
            : base(message) { }
    }
}
