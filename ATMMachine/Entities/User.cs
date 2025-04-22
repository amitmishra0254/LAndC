using System.ComponentModel.DataAnnotations;

namespace ATMMachine.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; } 
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public Account Account { get; set; }
    }
}
