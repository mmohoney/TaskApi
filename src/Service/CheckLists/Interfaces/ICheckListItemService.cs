using System.Collections.Generic;
using Domain.CheckLists;

namespace Service.CheckLists.Interfaces
{
    public interface ICheckListItemService
    {
        List<CheckListItemEntity> GetAllCheckListItemsByCheckListId(int checkListId);
        CheckListItemEntity GetCheckListItemById(int id);
        CheckListItemEntity CreateCheckListItem(CheckListItemEntity checkListItem);
        CheckListItemEntity UpdateCheckList(CheckListItemEntity checkListItem);
        void DeleteCheckListItemById(int id);
    }
}