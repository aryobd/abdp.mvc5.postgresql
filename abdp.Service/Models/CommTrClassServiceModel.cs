using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abdp.Service.Models
{
    public class CommTrClassServiceModel
    {
        public Int16 group_code { get; set; }
        public string class_code { get; set; }
        public string class_desc { get; set; }
        public Int16? meter_size_code { get; set; }
        
        public string group_desc { get; set; }
    }
}
