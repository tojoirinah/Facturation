using Facturation.RepositoryHelper.Base;

namespace Facturation.RepositoryHelper.Models
{
    public class UserRole : BaseEntity<int>
    {
        public string RoleName { get; set; }
    }
}
