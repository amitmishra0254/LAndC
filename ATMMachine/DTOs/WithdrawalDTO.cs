namespace ATMMachine.DTOs
{
    public class WithdrawalDTO
    {
        public int AtmId { get; set; }
        public string CardNumber { get; set; }
        public int Pin { get; set; }
        public decimal Amount { get; set; }
    }
}
