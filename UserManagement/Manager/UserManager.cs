using System.CodeDom;
using UserManagement.DAL.Repositories;
using UserManagement.DTOs;
using UserManagement.Entities;
using UserManagement.Exceptions;
using UserManagement.Utilities;

namespace UserManagement.Manager
{
    public class UserManagerImp : UserManager
    {
        private readonly UserRepository userRepository;
        public UserManagerImp(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<int> CreateUser(UserDTO userDto)
        {
            User user = new User()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Age = userDto.Age,
            };
            return await this.userRepository.CreateUser(user);
        }

        public async Task<UserDTO> GetUser(int Id)
        {
            User user = await this.userRepository.GetUser(Id);
            UserDTO userDto = new UserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
            };
            return userDto;
        }

        public async Task<int> DeleteUser(int Id)
        {
            return await this.userRepository.DeleteUser(Id);
        }

        public async Task<int> UpdateUser(int Id, UserDTO userDto)
        {
            User existingUser = await this.userRepository.GetUser(Id);
            User user = new User()
            {
                Id = existingUser.Id,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Age = userDto.Age,
            };
            return await this.userRepository.UpdateUser(user);
        }
    }

    public interface UserManager
    {
        Task<int> UpdateUser(int Id, UserDTO userDto);
        Task<int> DeleteUser(int Id);
        Task<UserDTO> GetUser(int Id);
        Task<int> CreateUser(UserDTO userDto);
    }
}
