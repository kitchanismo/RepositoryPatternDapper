using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperTest.Models;
using MicroOrm.Pocos.SqlGenerator;
using Dapper;
namespace DapperTest
{
    public class StudentRepository : Repository<Students>, IStudentRepository
    {
        public StudentRepository(IDbConnection connection,ISqlGenerator<Students> sqlGenerator)
          : base(connection, sqlGenerator)
        {
        }
        
        public IEnumerable<int> GetStudentAge()
        {
            return Connection.Query<int>("select age from students").ToArray();
        }

        public IEnumerable<string> GetStudentAgeAbove50()
        {
            return Connection.Query<string>("select name from students where age>@age", new { Age = 50}).ToArray();
        }

    }
}
