using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abdp.Service.Models
{
    public class CommTrClassServiceModel
    {
        public int group_code { get; set; }
        public string class_code { get; set; }
        public string class_desc { get; set; }
        public int? meter_size_code { get; set; }
        
        public string group_desc { get; set; }
    }
}
