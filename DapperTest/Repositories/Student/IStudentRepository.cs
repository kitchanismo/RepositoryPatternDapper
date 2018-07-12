using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperTest.Models;

namespace DapperTest
{
    public interface IStudentRepository : IRepository<Students>
    {
        IEnumerable<int> GetStudentAge();
        IEnumerable<string> GetStudentAgeAbove50();
    }
}
