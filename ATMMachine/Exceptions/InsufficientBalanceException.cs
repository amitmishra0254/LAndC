using ATMMachine.Constants;

namespace ATMMachine.Exceptions
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message)
            : base(message) { }
    }
}
