using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroOrm.Pocos.SqlGenerator.Attributes;

namespace DapperTest.Models
{
    public class Person
    {
        [KeyProperty]
        public string Name { get; set; }
        [KeyProperty]
        public int Age { get; set; }
        [KeyProperty]
        public string Address { get; set; }
    }
}
