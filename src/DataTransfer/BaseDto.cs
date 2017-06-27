using System;

namespace DataTransfer
{
    public abstract class BaseDto<T>
    {
        public virtual T Id { get; set; }
        public string CreatedUsername { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public string ModifiedUsername { get; set; }
        public DateTime ModifiedTimestamp { get; set; }
    }
}
