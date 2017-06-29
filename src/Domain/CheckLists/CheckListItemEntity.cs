using System;
using DataTransfer.CheckLists;

namespace Domain.CheckLists
{
    public class CheckListItemEntity : BaseEntity<int, CheckListItemDto>
    {
        public int CheckListId { get; set; }
        public bool IsComplete { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool Active { get; set; }

        public static CheckListItemEntity FromDto(CheckListItemDto dto)
        {
            CheckListItemEntity entity = new CheckListItemEntity
            {
                CheckListId = dto.CheckListId,
                IsComplete = dto.IsComplete,
                Description = dto.Description,
                DueDate = dto.DueDate,
                Active = dto.Active
            };
            entity.FromDtoInternal(dto);
            return entity;
        }

        public override CheckListItemDto ToDto()
        {
            CheckListItemDto dto = base.ToDto();
            dto.CheckListId = CheckListId;
            dto.IsComplete = IsComplete;
            dto.Description = Description;
            dto.DueDate = DueDate;
            dto.Active = Active;
            return dto;
        }
    }
}