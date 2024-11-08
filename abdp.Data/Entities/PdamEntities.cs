using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace abdp.Data.Entities
{
    public partial class PdamEntities : DbContext
    {
        public PdamEntities() : base("pdam_Entities")
        {
        }

        public virtual DbSet<comm_tr_group> comm_tr_group { get; set; }
        public virtual DbSet<comm_tr_class> comm_tr_class { get; set; }
    }
}
