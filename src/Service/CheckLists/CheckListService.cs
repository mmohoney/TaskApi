using System.Collections.Generic;
using System.Linq;
using DataAccess.Implementations.CheckLists.Interfaces;
using DataTransfer.CheckLists;
using Domain.CheckLists;
using Service.CheckLists.Interfaces;

namespace Service.CheckLists
{
    public class CheckListService : ICheckListService
    {
        private readonly ICheckListDao _checkListDao;

        public CheckListService(ICheckListDao checkListDao)
        {
            _checkListDao = checkListDao;
        }

        public List<CheckListEntity> GetAllCheckListsForUser(int userId)
        {
            List<CheckListDto> checkLists = _checkListDao.GetAllCheckListsForUser(userId);
            List<CheckListEntity> entities = checkLists.Select(c => CheckListEntity.FromDto(c)).ToList();
            return entities;
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
