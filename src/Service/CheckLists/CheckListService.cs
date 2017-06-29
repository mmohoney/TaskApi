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

        public List<CheckListEntity> GetAllCheckListsForUserId(int userId)
        {
            List<CheckListDto> checkLists = _checkListDao.GetAllCheckListsForUserId(userId);
            List<CheckListEntity> entities = checkLists.Select(CheckListEntity.FromDto).ToList();
            return entities;
        }

        public CheckListEntity GetCheckListById(int id)
        {
            CheckListDto checkList = _checkListDao.GetCheckListById(id);
            CheckListEntity entity = CheckListEntity.FromDto(checkList);
            return entity;
        }

        public CheckListEntity CreateCheckList(CheckListEntity checkList)
        {
            CheckListDto dto = checkList.ToDto();
            _checkListDao.CreateCheckList(dto);
            return GetCheckListById(dto.Id);
        }

        public CheckListEntity UpdateCheckList(CheckListEntity checkList)
        {
            CheckListDto dto = checkList.ToDto();
            _checkListDao.UpdateCheckList(dto);
            return GetCheckListById(dto.Id);
        }

        public void DeleteCheckListById(int id)
        {
            _checkListDao.DeleteCheckListById(id);
        }
    }
}
