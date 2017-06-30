using System.Collections.Generic;
using DataTransfer.CheckLists;
using Domain.Users;

namespace Domain.CheckLists
{
    public class CheckListEntity : BaseEntity<int, CheckListDto>
    {
        public int UserId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        //TODO: Ideally this entire structure would be populated from the DB in one hit.
        //public UserEntity User { get; set; }
        //public List<CheckListItemEntity> Items { get; set; } = new List<CheckListItemEntity>();

        public static CheckListEntity FromDto(CheckListDto dto)
        {
            CheckListEntity entity = new CheckListEntity
            {
                UserId = dto.UserId,
                Description = dto.Description,
                Active = dto.Active,
            };
            entity.FromDtoInternal(dto);
            return entity;
        }

        public override CheckListDto ToDto()
        {
            CheckListDto dto = base.ToDto();
            dto.UserId = UserId;
            dto.Description = Description;
            dto.Active = Active;
            return dto;
        }
    }
}