using DataTransfer.CheckLists;

namespace Domain.CheckLists
{
    public class CheckListEntity : BaseEntity<int, CheckListDto>
    {
		public int UserId { get; set; }

        public static CheckListEntity FromDto(CheckListDto dto)
        {
            CheckListEntity entity = new CheckListEntity
            {
                UserId = dto.UserId,
            };
            entity.FromDtoInternal(dto);
            return entity;
        }

        public override CheckListDto ToDto()
        {
            CheckListDto dto = base.ToDto();
            dto.UserId = UserId;
            return dto;
        }
    }
}