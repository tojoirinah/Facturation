using System;

namespace Facturation.RepositoryHelper.Base
{
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }

    public class BaseEntity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
        public virtual DateTime DateCreated { get; set; }
    }
}
