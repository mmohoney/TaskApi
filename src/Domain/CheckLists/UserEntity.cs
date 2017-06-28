using DataTransfer.CheckLists;

namespace Domain.CheckLists
{
    public class UserEntity : BaseEntity<int, UserDto>
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public static UserEntity FromDto(UserDto dto)
        {
            UserEntity entity = new UserEntity
            {
                Username = dto.Username,
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                LastName = dto.LastName,
            };
            entity.FromDtoInternal(dto);
            return entity;
        }

        public override UserDto ToDto()
        {
            UserDto dto = base.ToDto();
            dto.Username = Username;
            dto.FirstName = FirstName;
            dto.MiddleName = MiddleName;
            dto.LastName = LastName;
            return dto;
        }
    }
}
