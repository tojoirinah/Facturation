using Facturation.RepositoryHelper.Base;
using System;

namespace Facturation.RepositoryHelper.Models
{
    public class User : BaseEntity<int>
    {
        public Guid UserGuid { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int IdUserRole { get; set; }

        // navigation
        public virtual UserRole UserRole { get; set }
    }
}
