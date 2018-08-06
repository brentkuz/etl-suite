using ETLSuite.Business.Objects;
using ETLSuite.Crosscutting.Enums;
using ETLSuite.Models.Project.Tabs.EditModals.DbConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETLSuite.Models.Factories
{
    public interface IDbConnectionDefinitionViewModelFactory
    {
        object GetViewModel(DbConnectionDefinitionBase definition);
    }
    public class DbConnectionDefinitionViewModelFactory : IDbConnectionDefinitionViewModelFactory
    {
        private Dictionary<DatabaseType, Func<DbConnectionDefinitionBase, object>> map = new Dictionary<DatabaseType, Func<DbConnectionDefinitionBase, object>>()
        {
            {
                DatabaseType.SqlServer,
                new Func<DbConnectionDefinitionBase, object>(def =>
                {
                    SqlServerConnectionDefinition d = (SqlServerConnectionDefinition)def;
                    var cs = d.ConnectionString;
                    var res = new SqlServerConnectionDefinitionViewModel()
                    {
                        Id = d.Id,
                        Name = d.Name,
                        Description = d.Description,
                        DataSource = cs.DataSource,
                        InitialCatalog = cs.InitialCatalog,
                        ConnectionRetryCount = cs.ConnectRetryCount,
                        ConnectionRetryInterval = cs.ConnectRetryInterval,
                        Encrypt = cs.Encrypt,
                        IntegratedSecurity = cs.IntegratedSecurity,
                        MultipleActiveResultSets = cs.MultipleActiveResultSets,
                        Password = cs.Password,
                        UserID = cs.UserID,
                        ConnectionStringDisplay = cs.ConnectionString
                    };
                    return res;
                })
            }
        };
        public object GetViewModel(DbConnectionDefinitionBase definition)
        {
            var ctor = map[definition.Type];
            return ctor(definition);
        }
    }
}
