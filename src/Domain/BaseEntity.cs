using System;

namespace Domain
{
    public abstract class BaseEntity<T>
    {
        public virtual T Id { get; set; }
        public string CreatedUsername { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public string ModifiedUsername { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
