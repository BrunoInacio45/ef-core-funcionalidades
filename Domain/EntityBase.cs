using System;

namespace EFCore.Domain
{
    public class EntityBase
    {
        public EntityBase()
        {
            this.Id = Guid.NewGuid();

        }
        public Guid Id { get; protected set; }
    }
}