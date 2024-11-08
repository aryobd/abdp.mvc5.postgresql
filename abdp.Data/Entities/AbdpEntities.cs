using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abdp.Data.Entities
{
    public partial class AbdpEntities : DbContext
    {
        public AbdpEntities() : base("abdp_Entities")
        {
        }

        public virtual DbSet<tm_olss_brand> tm_olss_brand { get; set; }
        public virtual DbSet<tm_olss_model_vehicle> tm_olss_model_vehicle { get; set; }
    }
}
