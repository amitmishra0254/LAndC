using ATMMachine.Constants;

namespace ATMMachine.Exceptions
{
    public class CardBlockedException : Exception
    {
        public CardBlockedException(string message)
            : base(message) { }

        public CardBlockedException(string message, string cardNumber) 
            :base(string.Format(message, cardNumber)) { }

        public CardBlockedException(string message, string cardNumber, int attempts)
            : base(string.Format(message, cardNumber,attempts)) { }
    }
}
