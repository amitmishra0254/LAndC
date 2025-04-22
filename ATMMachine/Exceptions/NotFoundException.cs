namespace ATMMachine.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message, string cardNumber) : base(string.Format(message,cardNumber))
        {
            
        }
    }
}
