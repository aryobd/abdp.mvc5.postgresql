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
        [Column("group_code")]
        [Required]
        public Int16 GroupCode { get; set; }

        [Column("group_desc")]
        public string GroupDesc { get; set; }
    }
}
