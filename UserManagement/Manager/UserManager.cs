using System.CodeDom;
using UserManagement.DTOs;
using UserManagement.Exceptions;
using UserManagement.Utilities;

namespace UserManagement.Manager
{
    public interface UserManager
    {
        Task<int> UpdateUser(int Id, UserDTO userDto);
        Task<int> DeleteUser(int Id);
        Task<UserDTO> GetUser(int Id);
        Task<int> CreateUser(UserDTO userDto);
    }
}
