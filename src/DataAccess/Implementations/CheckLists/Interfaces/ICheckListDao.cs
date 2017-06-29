using System.Collections.Generic;
using DataTransfer.CheckLists;

namespace DataAccess.Implementations.CheckLists.Interfaces
{
    public interface ICheckListDao : IBaseDao
    {
        List<CheckListDto> GetAllCheckLists();
        List<CheckListDto> GetAllCheckListsForUserId(int userId);
        CheckListDto GetCheckListById(int id);
        void CreateCheckList(CheckListDto dto);
        void UpdateCheckList(CheckListDto dto);
        void DeleteCheckListById(int id);
    }
}