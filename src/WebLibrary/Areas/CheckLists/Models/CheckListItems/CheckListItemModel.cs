using System;

namespace WebLibrary.Areas.CheckLists.Models.CheckListItems
{
    public class CheckListItemModel
    {
        public int Id { get; set; }
        public int CheckListId { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public string CreatedUsername { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public string ModifiedUsername { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}