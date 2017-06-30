using System.Collections.Generic;
using DataTransfer.Users;

namespace DataTransfer.CheckLists
{
    public class CheckListDto : BaseDto<int>
    {
		public int UserId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        //TODO: Ideally this entire structure would be populated from the DB in one hit.
        //public UserDto User { get; set; }
        //public List<CheckListItemDto> Items { get; set; } = new List<CheckListItemDto>();
    }
}