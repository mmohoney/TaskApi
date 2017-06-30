using System;
using DataTransfer;

namespace Domain
{
    /// <summary>
    /// Base entity with id and audit fields
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TDto"></typeparam>
    public abstract class BaseEntity<T, TDto> where TDto : BaseDto<T>, new()
    {
        public virtual T Id { get; set; }

        //TODO: Authorize user using openid. Use identity to always pass into DB to build audit tables
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
