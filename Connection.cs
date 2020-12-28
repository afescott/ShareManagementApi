using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCodeCamp
{
    public class Connection
    {
        private const string connectionString =
    @"Data Source=politiquality.database.windows.net;Initial Catalog=PolitiQuality;User ID=s4908683;Password=#afafaf";
        
        private SqlCommand Con = new SqlCommand();

        public Connection()
        {
           //var k = Con.
        }
    }
}
