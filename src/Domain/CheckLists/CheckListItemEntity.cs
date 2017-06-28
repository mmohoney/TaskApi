using DataTransfer.CheckLists;

namespace Domain.CheckLists
{
    public class CheckListItemEntity : BaseEntity<int, CheckListItemDto>
    {
        public int CheckListId { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }

        public static CheckListItemEntity FromDto(CheckListItemDto dto)
        {
            CheckListItemEntity entity = new CheckListItemEntity
            {
                CheckListId = dto.CheckListId,
                Description = dto.Description,
                IsComplete = dto.IsComplete,
            };
            entity.FromDtoInternal(dto);
            return entity;
        }

        public override CheckListItemDto ToDto()
        {
            CheckListItemDto dto = base.ToDto();
            dto.CheckListId = CheckListId;
            dto.Description = Description;
            dto.IsComplete = IsComplete;
            return dto;
        }
    }
}