using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntSysLaba5v3
{
    internal class Accrue
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int EmploeeTabNumber { get; set; }
        public int Accrued { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}

