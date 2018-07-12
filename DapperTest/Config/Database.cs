using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTest
{
    public static class Database
    {
        public static IDbConnection Connection = new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=mysample;Integrated Security=True");
    }
}
