using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroOrm.Pocos.SqlGenerator.Attributes;
namespace DapperTest.Models
{
    public class Students : Person
    {
        [KeyProperty(Identity = true)]
        public int Id { get; set; }
        [KeyProperty]
        public string Course { get; set; }
        [KeyProperty]
        public int YearLevel { get; set; }
        [KeyProperty]
        public string School { get; set; }
    }
}
