namespace ATMMachine.Constants
{
    public class ApplicationConstant
    {
        public static int SavingAccountDailyLimt = 20000;
        public static int CurrentAccountDailyLimt = 50000;
        public static int InvalidPinLimit = 3;

        public const string CardBlockException = "Your card is blocked. Please contact your bank to unblock it.";
        public const string CardBlockExceptionWithLastAttempt = "Invalid PIN for Card: {0}. You have reached the maximum number of attempts. Your card is now blocked. Please contact your bank to unblock it.";
        public const string CardBlockExceptionWithAttempts = "Invalid PIN for Card: {0}. You have {1} attempt(s) left.";
        public const string InsufficientBalanceMessage = "Insufficient balance in account.";
        public const string InsufficientAtmCashMessage = "Insufficient cash in ATM.";
        public const string DailyLimitExceededMessage = "Daily limit reached! You cannot withdraw more today.";
        public const string UserNotFoundException = "User not found with card number: {0}";

        public const string ServerAvailabilityQuery = "SELECT 1";
        public const string ServerNotAvailableException = "Server is currently unavailable.Please try again later.";
    }
}
