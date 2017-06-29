using System.Collections.Generic;
using System.Linq;
using DataAccess.Implementations.Users.Interfaces;
using DataTransfer.Users;

namespace DataAccess.Implementations.Users
{
    public class UserDao : BaseDao, IUserDao
    {
        public List<UserDto> GetAllUsers()
        {
            return DbSqlMapper.SqlMapper.QueryForList<UserDto>("UserMap.GetAllUsers", null).ToList();
        }

        public UserDto GetUserById(int id)
        {
            return DbSqlMapper.SqlMapper.QueryForObject<UserDto>("UserMap.GetUserById", id);
        }

        public void CreateUser(UserDto dto)
        {
            DbSqlMapper.SqlMapper.Insert("UserMap.CreateUser", dto);
        }

        public void UpdateUser(UserDto dto)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteUserById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
