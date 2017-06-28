using System.Collections.Generic;
using DataAccess.Implementations.CheckLists;
using Domain.CheckLists;

namespace Service.CheckLists
{
    public class CheckListService
    {
        private readonly CheckListDao _checkListDao = new CheckListDao();

        public List<CheckListEntity> GetAllCheckListsForUser(int userId)
        {
            return new List<CheckListEntity>();
        }

        public CheckListEntity GetCheckListById(int checkListId)
        {
            return new CheckListEntity();
        }

        public CheckListEntity CreateCheckList(CheckListEntity entity)
        {
            return new CheckListEntity();
        }

        public CheckListEntity UpdateCheckList(CheckListEntity entity)
        {
            return new CheckListEntity();
        }

        public void DeleteCheckList(int id)
        {
            
        }
    }
}
