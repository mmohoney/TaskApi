using System.Collections.Generic;
using System.Linq;
using DataAccess.Implementations.CheckLists.Interfaces;
using DataTransfer.CheckLists;
using Domain.CheckLists;
using Service.CheckLists.Interfaces;

namespace Service.CheckLists
{
    public class CheckListItemService : ICheckListItemService
    {
        private readonly ICheckListItemDao _checkListItemDao;

        public CheckListItemService(ICheckListItemDao checkListItemDao)
        {
            _checkListItemDao = checkListItemDao;
        }

        public List<CheckListItemEntity> GetAllCheckListItemsByCheckListId(int checkListId)
        {
            List<CheckListItemDto> checkLists = _checkListItemDao.GetAllCheckListItemsByCheckListId(checkListId);
            List<CheckListItemEntity> entities = checkLists.Select(CheckListItemEntity.FromDto).ToList();
            return entities;
        }

        public CheckListItemEntity GetCheckListItemById(int id)
        {
            CheckListItemDto checkList = _checkListItemDao.GetCheckListItemById(id);
            CheckListItemEntity entity = CheckListItemEntity.FromDto(checkList);
            return entity;
        }

        public CheckListItemEntity CreateCheckListItem(CheckListItemEntity checkListItem)
        {
            CheckListItemDto dto = checkListItem.ToDto();
            _checkListItemDao.CreateCheckListItem(dto);
            return GetCheckListItemById(dto.Id);
        }

        public CheckListItemEntity UpdateCheckList(CheckListItemEntity checkListItem)
        {
            CheckListItemDto dto = checkListItem.ToDto();
            _checkListItemDao.UpdateCheckListItem(dto);
            return GetCheckListItemById(dto.Id);
        }

        public void DeleteCheckListItemById(int id)
        {
            _checkListItemDao.DeleteCheckListItemById(id);
        }
    }
}
