using System;

namespace DataTransfer.CheckLists
{
    public class CheckListItemDto : BaseDto<int>
    {
        public int CheckListId { get; set; }
        public bool IsComplete { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}