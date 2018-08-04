using System;
using System.Collections.Generic;
using System.Text;

namespace ETLSuite.Crosscutting.Enums
{
    public enum DatabaseType
    {
        SqlServer,
        ODBC,
        Oracle
    }

    public static class DatabaseTypeExtensions
    {
        private static Dictionary<DatabaseType, string> typeToDisplayMap = new Dictionary<DatabaseType, string>
        {
            { DatabaseType.SqlServer, "Sql Server" },
            { DatabaseType.ODBC, "ODBC" },
            { DatabaseType.Oracle, "Oracle" }
        };

        public static string ToDisplay(this DatabaseType type)
        {
            return typeToDisplayMap[type];
        }
    }


}
