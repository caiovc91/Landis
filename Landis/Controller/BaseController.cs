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
        public void InsertEndpoint(Endpoint enp)
        {

            try
            {
                endpoints.Add(enp);
                Console.WriteLine("New Endpoint added succesfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error: \n" + ex.ToString());
            }
        }

        enum states
        {
            Disconnected = 0,
            Connected = 1,
            Armed = 2
        }

        public void EditEndpoint(string serial_number, int switch_state)
        {

            var sel_endpoint = endpoints.Where(e => e.serial_number == serial_number).FirstOrDefault();
            try
            {
                if (Enum.IsDefined(typeof(states), switch_state))
                    sel_endpoint.switch_state = switch_state;
                else
                {
                    Console.WriteLine("Invalid state! Enter a new one!");
                    string temp = Console.ReadLine();
                }

                Console.WriteLine("Switch state changed! \n Previous: " + switch_state + "\n Actual: " + sel_endpoint.switch_state);
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error: \n" + ex.ToString());
            }

        }

        public void DeleteEndpoint(int id)
        {
            var sel_endpoint = endpoints.Where(e => e.Id == id).FirstOrDefault();
            endpoints.Remove(sel_endpoint);
            Console.WriteLine("Endpoint removed successfully.");
        }

        public void ListAllEndpoints()
        {
            Console.WriteLine("------------ Endpoints List ------------");
            foreach (Endpoint endpoint in endpoints.ToList())
            {
                Console.WriteLine(endpoint);
            }
        }
    }
}
