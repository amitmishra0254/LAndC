using System.ComponentModel.DataAnnotations;

namespace ATMMachine.DTOs
{
    public class DepositRequestDTO
    {
        public string CardNumber { get; set; }
        [Range(1, (double)decimal.MaxValue)]
        public decimal Amount { get; set; }
        [Range(1, int.MaxValue)]
        public int ATMId { get; set; }
    }
}
