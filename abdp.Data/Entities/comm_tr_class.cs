using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abdp.Data.Entities
{
    [Table("tr_class", Schema = "comm")]
    public partial class comm_tr_class
    {
        [Key]
        [Column(Order = 0)]
        public int group_code { get; set; }
        [Key]
        [Column(Order = 1)]
        public string class_code { get; set; }

        public string class_desc { get; set; }
        public int? meter_size_code { get; set; }
    }
}
