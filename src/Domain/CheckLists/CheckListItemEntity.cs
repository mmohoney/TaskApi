namespace Domain.CheckLists
{
    public class CheckListItemEntity : BaseEntity<int>
    {
        public int CheckListId { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
    }
}