using ATMMachine.Enums;

namespace ATMMachine.DTOs
{
    public class UserDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
    }

    public class AccountDTO
    {
        public int Pin { get; set; }
        public AccountType AccountType { get; set; }
    }

    public class CreateUserRequestDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public AccountDTO AccountDetails { get; set; }
    }
}
