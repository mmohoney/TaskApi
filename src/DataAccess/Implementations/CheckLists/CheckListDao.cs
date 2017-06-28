using System.Collections.Generic;
using System.Linq;
using DataAccess.Implementations.CheckLists.Interfaces;
using DataTransfer.CheckLists;

namespace DataAccess.Implementations.CheckLists
{
    public class CheckListDao : ICheckListDao
    {
        public List<UserDto> GetAllUsers()
        {
            return DbSqlMapper.SqlMapper.QueryForList<UserDto>("CheckListMap.GetAllUsers", null).ToList();
        }

        public List<CheckListDto> GetAllCheckListsForUser(int userId)
        {
            return DbSqlMapper.SqlMapper.QueryForList<CheckListDto>("CheckListMap.GetAllCheckListsForUser", userId).ToList();
        }

        public CheckListDto GetCheckListById(int checkListId)
        {
            return new CheckListDto();
        }

        public CheckListDto CreateCheckList(CheckListDto entity)
        {
            return new CheckListDto();
        }

        public CheckListDto UpdateCheckList(CheckListDto entity)
        {
            return new CheckListDto();
        }

        public void DeleteCheckList(int id)
        {

        }
    }
}
