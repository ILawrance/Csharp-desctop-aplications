using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntSysLaba5v3
{
    internal class BonusList
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int EmploeeTabNumber { get; set; }
        public string EmloeeFIO { get; set; }
        public string EmploeePost { get; set; }
        public string EmploeeExperience { get; set; }
        public int EmploeeSalary { get; set; }
        public int EmploeeAccrued { get; set; }
        public int EmploeePocentBonus { get; set; }
        public int EmploeeSummOfBunus { get; set; }
        public virtual Employee Employee { get; set; }
    }
}