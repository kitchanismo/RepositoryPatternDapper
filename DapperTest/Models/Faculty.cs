using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTest.Models
{
    public class Faculty : Person
    {
        public int Id { get; set; }
        public string Subject { get; set; }
    }
}
