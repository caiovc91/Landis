using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landis.Models
{
    public class MeterModel
    {
        public MeterModel(int modelId)
        {
            ModelId = modelId;

            if (modelId == 16)
            {
                ModelName =  "NSX1P2W";
            }
            else if(modelId == 17)
            {
                ModelName =  "NSX1P3W";
            }
            else if (modelId == 18)
            {
                ModelName =  "NSX2P3W";
            }
            else if (modelId == 19)
            {
                ModelName = "NSX3P4W";
            }
            else
            {
                ModelName = "INVALID";
            }
        }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
    }
}
