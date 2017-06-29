using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Implementations.CheckLists.Interfaces;
using DataTransfer.CheckLists;

namespace DataAccess.Implementations.CheckLists
{
    public class CheckListItemDao : BaseDao, ICheckListItemDao
    {
        public List<CheckListItemDto> GetAllCheckListItems()
        {
            return DbSqlMapper.SqlMapper.QueryForList<CheckListItemDto>("CheckListItemMap.GetAllCheckListItems", null).ToList();
        }

        public List<CheckListItemDto> GetAllCheckListItemsByCheckListId(int checkListId)
        {
            return DbSqlMapper.SqlMapper.QueryForList<CheckListItemDto>("CheckListItemMap.GetAllCheckListItemsByCheckListId", checkListId).ToList();
        }

        public CheckListItemDto GetCheckListItemById(int id)
        {
            return DbSqlMapper.SqlMapper.QueryForObject<CheckListItemDto>("CheckListItemMap.GetCheckListItemById", id);
        }

        public void CreateCheckListItem(CheckListItemDto dto)
        {
            DbSqlMapper.SqlMapper.Insert("CheckListItemMap.CreateCheckListItem", dto);
        }

        public void UpdateCheckListItem(CheckListItemDto dto)
        {
            DbSqlMapper.SqlMapper.Update("CheckListItemMap.UpdateCheckListItem", dto);
        }

        public void DeleteCheckListItemById(int id)
        {
            DbSqlMapper.SqlMapper.Delete("CheckListItemMap.DeleteCheckListItemById", id);
        }
    }
}
