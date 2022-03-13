using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Landis.Models;

namespace Landis
{
    public class Endpoint
    {
        public string serial_number { get; set; }

        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid model id")]
        public MeterModel MeterModel { get; set; }
        public int meter_number { get; set; }
        public string firmware_version { get; set; }

        [RegularExpression("([0-2])", ErrorMessage = "Please enter valid switch state")]
        public int switch_state { get; set; }
    }
    enum states
    {
        Disconnected = 0,
        Connected = 1,
        Armed = 2
    }
}
