using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Landis.Models;

namespace Landis.Controller
{
    public class BaseController
    {
        public List<Endpoint> endpoints = new List<Endpoint>
        {
            new Endpoint {Id = 1, serial_number = "NSX1P2W", model_id = 16, meter_number = 5123556, firmware_version = "revA.2022.Landis", switch_state = 1 },
            new Endpoint {Id = 1, serial_number = "NSX1P3W", model_id = 17, meter_number = 5123556, firmware_version = "revA1.2022.Landis", switch_state = 2 },
            new Endpoint {Id = 1, serial_number = "NSX2P3W", model_id = 18, meter_number = 5123556, firmware_version = "revA.2022.Landis", switch_state = 0 },
            new Endpoint {Id = 1, serial_number = "NSX3P4W", model_id = 19, meter_number = 5123556, firmware_version = "revA.2022.Landis", switch_state = 2 },
        };
        public void InsertEndpoint(int id, string serial_number, int model_id, int meter_number, string firmware_version, int switch_state)
        {

            Endpoint newEndpoint = new Endpoint();
            try
            {
                newEndpoint.Id = id;
                newEndpoint.serial_number = serial_number;
                newEndpoint.meter_number = meter_number;
                newEndpoint.firmware_version = firmware_version;
                newEndpoint.switch_state = switch_state;
                endpoints.Add(newEndpoint);

                Console.WriteLine("New Endpoint added succesfully");
            }
            catch (Exception ex)
            {

                throw;
            }





        }

        public Endpoint EditEndpoint(Endpoint endpoint, int switch_state)
        {
            var sel_endpoint = endpoints.Where(e => e.Id == endpoint.Id).FirstOrDefault();
            sel_endpoint.switch_state = switch_state;
            return sel_endpoint;
        }
        
        public void DeleteEndpoint(int id)
        {
            var sel_endpoint = endpoints.Where(e => e.Id == id).FirstOrDefault();
            endpoints.Remove(sel_endpoint);
            Console.WriteLine("Endpoint removed successfully.");
        }

        public void ListAllEndpoints(string company, IEnumerable<Endpoint> list)
        {
            Console.WriteLine("------------Endpoints List - Company [" + company + "]------------");
            foreach (Endpoint endpoint in list)
            {
                Console.WriteLine(endpoint);
            }
        }
    }
}
