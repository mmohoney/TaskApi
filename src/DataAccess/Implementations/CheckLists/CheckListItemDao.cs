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
            throw new NotImplementedException();
        }

        public List<CheckListItemDto> GetAllCheckListItemsByCheckListId(int id)
        {
            throw new NotImplementedException();
        }

        public CheckListItemDto GetCheckListItemById(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateCheckListItem(CheckListItemDto dto)
        {
            throw new NotImplementedException();
        }

        public void UpdateCheckListItem(CheckListItemDto dto)
        {
            throw new NotImplementedException();
        }

        public void DeleteCheckListItemById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
