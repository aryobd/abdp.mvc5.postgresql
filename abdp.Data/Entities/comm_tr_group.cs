using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abdp.Data.Entities
{
    [Table("tr_group", Schema = "comm")]
    public partial class comm_tr_group
    {
        [Key]
        public int group_code { get; set; }
        public string group_desc { get; set; }
    }
}
