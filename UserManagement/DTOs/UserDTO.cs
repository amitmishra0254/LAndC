using System.ComponentModel.DataAnnotations;

namespace UserManagement.DTOs
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int Age { get; set; }
    }
}
