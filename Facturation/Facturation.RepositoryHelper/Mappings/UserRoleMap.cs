using Facturation.RepositoryHelper.Models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Facturation.RepositoryHelper.Mappings
{
    public class UserRoleMap : ClassMapping<UserRole>
    {
        public UserRoleMap()
        {
            Table("UserRole");
            Schema("dbo");

            Id(x => x.Id, map => map.Generator(Generators.Native));
            Property(x => x.RoleName, map => map.NotNullable(true));
        }
    }
}
