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
        public PdamEntities() : base("abdp_Entities")
        {
        }

        public virtual DbSet<tm_olss_brand> tm_olss_brand { get; set; }
        public virtual DbSet<tm_olss_model_vehicle> tm_olss_model_vehicle { get; set; }
    }
}
