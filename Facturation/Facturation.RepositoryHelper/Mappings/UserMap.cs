using Facturation.RepositoryHelper.Models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Facturation.RepositoryHelper.Mappings
{
    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Table("User");
            Schema("dbo");

            Id(x => x.Id, map => map.Generator(Generators.Native));
            Property(x => x.UserGuid, map => map.NotNullable(true));
            Property(x => x.Name, map => map.NotNullable(true));
            Property(x => x.FirstName);
            Property(x => x.UserName, map => map.NotNullable(true));
            Property(x => x.Email, map => map.NotNullable(true));
            Property(x => x.Password);
            Property(x => x.DateCreated, map => map.NotNullable(true));
            Property(x => x.IdUserRole, map => map.NotNullable(true));
        }
    }
}
