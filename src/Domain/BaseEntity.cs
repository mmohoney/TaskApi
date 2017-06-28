using System;
using DataTransfer;

namespace Domain
{
    public abstract class BaseEntity<T, TDto> where TDto : BaseDto<T>, new()
    {
        public virtual T Id { get; set; }
        public string CreatedUsername { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public string ModifiedUsername { get; set; }
        public DateTime ModifiedTimestamp { get; set; }

        protected void FromDtoInternal(TDto dto)
        {
            Id = Id;
            CreatedUsername = CreatedUsername;
            CreatedTimestamp = CreatedTimestamp;
            ModifiedUsername = ModifiedUsername;
            ModifiedTimestamp = ModifiedTimestamp;
        }

        public virtual TDto ToDto()
        {
            return new TDto
            {
                Id = Id,
                CreatedUsername = CreatedUsername,
                CreatedTimestamp = CreatedTimestamp,
                ModifiedUsername = ModifiedUsername,
                ModifiedTimestamp = ModifiedTimestamp
            };
        }
    }
}
