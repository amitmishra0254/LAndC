using ATMMachine.Enums;

namespace ATMMachine.DTOs
{
    public class AccountDTO
    {
        public int Pin { get; set; }
        public AccountType AccountType { get; set; }
    }
}
