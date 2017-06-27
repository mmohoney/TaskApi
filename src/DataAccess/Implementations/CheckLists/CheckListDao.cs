using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransfer.CheckLists;

namespace DataAccess.Implementations.CheckLists
{
    public class CheckListDao
    {
        public List<UserDto> GetAllUsers()
        {
            return DbSqlMapper.SqlMapper.QueryForList<UserDto>("CheckListMap.GetAllUsers", null).ToList();
        }
    }
}
