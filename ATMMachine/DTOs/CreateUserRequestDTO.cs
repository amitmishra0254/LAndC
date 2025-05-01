namespace ATMMachine.DTOs
{
    public class CreateUserRequestDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public AccountDTO AccountDetails { get; set; }
    }
}
