using System.Collections.Generic;
using DataTransfer.CheckLists;

namespace DataAccess.Implementations.CheckLists.Interfaces
{
    public interface ICheckListDao
    {
        List<UserDto> GetAllUsers();
        List<CheckListDto> GetAllCheckListsForUser(int userId);
        CheckListDto GetCheckListById(int checkListId);
        CheckListDto CreateCheckList(CheckListDto entity);
        CheckListDto UpdateCheckList(CheckListDto entity);
        void DeleteCheckList(int id);
    }
}