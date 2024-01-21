using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntSysLaba5v3
{
    internal class MyDbContext : DbContext
    {
        public MyDbContext() : base("DbConnectionString")
        {
        }
        public DbSet<Employee> Employeers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Accrue> Accrues { get; set; }
        public DbSet<BonusList> BonusLists { get; set; }
    }
}