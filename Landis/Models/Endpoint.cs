using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landis
{
    public class Endpoint
    {
        public int Id { get; set; }
        public string serial_number { get; set; }
        public int model_id { get; set; }
        public int meter_number { get; set; }
        public string firmware_version { get; set; }
        public int switch_state { get; set; }
    }
}
