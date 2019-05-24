using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading.Tasks;

namespace testApp.Repository
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        public IDbConnection CreateConnection()
        {
            ResourceManager resource_manager = new ResourceManager("testApp.Resource", Assembly.GetExecutingAssembly());
            var connectionString = resource_manager.GetString("DbConnectionString");

            return new SqlConnection(connectionString);
        }
    }
}
