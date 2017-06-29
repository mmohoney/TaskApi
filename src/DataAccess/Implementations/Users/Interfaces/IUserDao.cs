using System.Collections.Generic;
using DataTransfer.CheckLists;

namespace DataAccess.Implementations.Users.Interfaces
{
    public interface IUserDao : IBaseDao
    {
        List<UserDto> GetAllUsers();
        UserDto GetUserById(int id);
        void CreateUser(UserDto dto);
        void UpdateUser(UserDto dto);
        void DeleteUserById(int id);
    }
}
