using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntSysLaba5v3
{
    internal class Employee
    {
        public int Id { get; set; }
        public int TabNumber { get; set; }
        public string FIO { get; set; }
        public string Position { get; set; }
        public string DateOfStratWorking { get; set; }
        public virtual Accrue Accrue { get; set; }
        public virtual Position PositionIn { get; set; }
        public virtual ICollection<BonusList> BonusLists { get; set; }
    }
}