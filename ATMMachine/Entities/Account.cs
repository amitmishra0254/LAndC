using ATMMachine.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATMMachine.Entities
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public int Pin { get; set; }
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public decimal DailyLimit { get; set; }
        public decimal TodayWithdrawnAmount { get; set; }
        public bool IsCardBlocked { get; set; }
        public int FailedPinAttempts { get; set; }
        public AccountType AccountType { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
