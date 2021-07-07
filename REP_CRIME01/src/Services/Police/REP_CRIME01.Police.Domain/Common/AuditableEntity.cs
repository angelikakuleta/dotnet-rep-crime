using System;

namespace REP_CRIME01.Police.Domain.Common
{
    public abstract class AuditableEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
