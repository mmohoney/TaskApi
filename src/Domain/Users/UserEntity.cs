using DataTransfer.Users;

namespace Domain.Users
{
    public class UserEntity : BaseEntity<int, UserDto>
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public static UserEntity FromDto(UserDto dto)
        {
            UserEntity entity = new UserEntity
            {
                Username = dto.Username,
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                LastName = dto.LastName,
                Email = dto.Email,
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
            dto.Email = Email;
            return dto;
        }
    }
}
