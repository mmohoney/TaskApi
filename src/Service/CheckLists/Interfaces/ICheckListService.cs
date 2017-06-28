using System.Collections.Generic;
using Domain.CheckLists;

namespace Service.CheckLists.Interfaces
{
    public interface ICheckListService
    {
        List<CheckListEntity> GetAllCheckListsForUser(int userId);
        CheckListEntity GetCheckListById(int checkListId);
        CheckListEntity CreateCheckList(CheckListEntity entity);
        CheckListEntity UpdateCheckList(CheckListEntity entity);
        void DeleteCheckList(int id);
    }
}