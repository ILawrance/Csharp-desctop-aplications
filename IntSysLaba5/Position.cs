using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntSysLaba5v3
{
    internal class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}