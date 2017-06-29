using System.Collections.Generic;
using System.Linq;
using DataAccess.Implementations.CheckLists.Interfaces;
using DataTransfer.CheckLists;

namespace DataAccess.Implementations.CheckLists
{
    public class CheckListDao : BaseDao, ICheckListDao
    {
        public List<CheckListDto> GetAllCheckLists()
        {
            return DbSqlMapper.SqlMapper.QueryForList<CheckListDto>("CheckListMap.GetAllCheckLists", null).ToList();
        }

        public List<CheckListDto> GetAllCheckListsByUserId(int id)
        {
            return DbSqlMapper.SqlMapper.QueryForList<CheckListDto>("CheckListMap.GetAllCheckListsByUserId", id).ToList();
        }

        public CheckListDto GetCheckListById(int id)
        {
            return DbSqlMapper.SqlMapper.QueryForObject<CheckListDto>("CheckListMap.GetCheckListById", id);
        }

        public void CreateCheckList(CheckListDto dto)
        {
            DbSqlMapper.SqlMapper.Insert("CheckListMap.CreateCheckList", dto);
        }

        public void UpdateCheckList(CheckListDto dto)
        {
            DbSqlMapper.SqlMapper.Update("CheckListMap.UpdateCheckList", dto);
        }

        public void DeleteCheckListById(int id)
        {
            DbSqlMapper.SqlMapper.Delete("CheckListMap.DeleteCheckListById", id);
        }
    }
}
