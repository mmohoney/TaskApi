namespace DataTransfer.CheckLists
{
    public class CheckListDto : BaseDto<int>
    {
		public int UserId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}