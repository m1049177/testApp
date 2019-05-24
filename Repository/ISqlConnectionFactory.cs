using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace testApp.Repository
{
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
