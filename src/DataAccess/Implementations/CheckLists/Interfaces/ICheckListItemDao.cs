using System.Collections.Generic;
using DataTransfer.CheckLists;

namespace DataAccess.Implementations.CheckLists.Interfaces
{
    public interface ICheckListItemDao : IBaseDao
    {
        List<CheckListItemDto> GetAllCheckListItems();
        List<CheckListItemDto> GetAllCheckListItemsByCheckListId(int checkListId);
        CheckListItemDto GetCheckListItemById(int id);
        void CreateCheckListItem(CheckListItemDto dto);
        void UpdateCheckListItem(CheckListItemDto dto);
        void DeleteCheckListItemById(int id);
    }
}
