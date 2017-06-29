using System.Collections.Generic;
using Domain.CheckLists;

namespace Service.CheckLists.Interfaces
{
    public interface ICheckListService
    {
        List<CheckListEntity> GetAllCheckListsForUserId(int userId);
        CheckListEntity GetCheckListById(int id);
        CheckListEntity CreateCheckList(CheckListEntity checkList);
        CheckListEntity UpdateCheckList(CheckListEntity checkList);
        void DeleteCheckListById(int id);
    }
}